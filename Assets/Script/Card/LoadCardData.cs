using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using static ICardType;

public class LoadCardData : MonoBehaviour
{
    [SerializeField] string url = "";
    [SerializeField] CardStorage _cardStorage;

    private void OnValidate()
    {
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Google Apps Scriptへのリクエスト中にエラーが発生しました: " + webRequest.error);
            }
            else
            {
                // スクリプトからのレスポンスを取得
                string response = webRequest.downloadHandler.text;
                CardDataStorage data = JsonUtility.FromJson<CardDataStorage>(response);
                if (data.Data.Length != _cardStorage.Storage.Count)
                {
                    foreach (var d in data.Data)
                    {
                        var name = d.Name;
                        var cost = d.Cost;
                        var attack = d.Attack;
                        var defense = d.Defense;
                        var image = d.ImageCord;
                        var type = d.CardType;
                        List<IAbility> ability = new List<IAbility>();
                        List<ICondition> condition = new List<ICondition>();
                        List<ITarget> target = new List<ITarget>();
                        Sprite cardImage = null;
                        CardType cardType = CardType.None;
                        foreach (var a in d.Ability)
                        {
                            if (a == (int)AbilityID.Test)
                            {
                                ability.Add(new TestAbility());
                            }
                        }
                        foreach (var c in d.Condition)
                        {
                            if (c == (int)ConditionID.Test)
                            {
                                condition.Add(new TestCondition());
                            }
                        }
                        foreach (var t in d.Target)
                        {
                            if (t == (int)TargetID.Test)
                            {
                                target.Add(new PlayerFieldTarget());
                            }
                        }
                        cardImage = Resources.Load<Sprite>(image);
                        if (type == "Character") cardType = CardType.Character;
                        if (type == "Spell") cardType = CardType.Spell;
                        _cardStorage.Storage.Add(new CardState(name, cost, attack, defense, cardImage, cardType, ability, condition, target));
                    }
                }
            }
        }
    }

}

enum AbilityID
{
    Test = 1,
    Damage,
}

enum ConditionID
{
    Test = 1,
}

enum TargetID
{
    Test = 1,
    PlayerField,
    PlayerHand,
    EnemyField,
    EnemyHand,
    All,
    Random,
}

[Serializable]
class CardDataStorage
{
    public CardData[] Data;
}

[Serializable]
class CardData
{
    public string Name;
    public string ImageCord;
    public string CardType;
    public int Cost;
    public int Attack;
    public int Defense;
    public int[] Ability;
    public int[] Condition;
    public int[] Target;
}

