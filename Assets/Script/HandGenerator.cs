using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGenerator : FieldData
{
    [SerializeField] CardStorage _storage;
    [SerializeField] GameObject _playerHandObject;
    [SerializeField] GameObject _enemyHandObject;
    private void Awake()
    {
        base.Awake();
        for (int i = 0; i < _storage.HandCount; i++)
        {
            int random = Random.Range(0, _storage.Storage.Length);
            var characterCard = new Character();
            characterCard.CardState = _storage.Storage[random];
            //SetHand(Target.Player, characterCard);
            CardSet(_storage.Storage[random], _playerHandObject, Target.Player);
            random = Random.Range(0, _storage.Storage.Length);
            var spellCard = new Spell();
            spellCard.CardState = _storage.Storage[random];
            //SetHand(Target.Enemy, spellCard);
            CardSet(_storage.Storage[random], _enemyHandObject, Target.Enemy);
        }
    }
    void CardSet(CardState selectCard, GameObject target, Target playerType)
    {
        if(selectCard.Type == CardState.CardType.Character)
        {
            var card = Instantiate((GameObject)Resources.Load("Character"), target.transform);
            card.GetComponent<CardBase>().CardState = selectCard;
            SetHand(playerType, card.GetComponent<CardBase>());
        }
        else if (selectCard.Type == CardState.CardType.Spell)
        {
            var card = Instantiate((GameObject)Resources.Load("Spell"), target.transform);
            card.GetComponent<CardBase>().CardState = selectCard;
            SetHand(playerType, card.GetComponent<CardBase>());
        }
    }
}
