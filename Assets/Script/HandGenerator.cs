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
    }
    void Start()
    {
        for(int i = 0; i < _storage.HandCount; i++)
        {
            int random = Random.Range(0, _storage.Storage.Length);
            SetHand(Target.Player, _storage.Storage[random]);
            CardSet(_storage.Storage[random], _playerHandObject);
            random = Random.Range(0, _storage.Storage.Length);
            SetHand(Target.Enemy, _storage.Storage[random]);
            CardSet(_storage.Storage[random], _enemyHandObject);
        }
        FieldData data = Set();
    }

    void CardSet(CardState selectCard, GameObject target)
    {
        if(selectCard.Type == CardState.CardType.Character)
        {
            var card = Instantiate((GameObject)Resources.Load("Character"), target.transform);
            card.GetComponent<Character>().CardState = selectCard;
        }
        else if (selectCard.Type == CardState.CardType.Spell)
        {
            var card = Instantiate((GameObject)Resources.Load("Spell"), target.transform);
            card.GetComponent<Spell>().CardState = selectCard;
        }
    }

    void Update()
    {
        
    }
}
