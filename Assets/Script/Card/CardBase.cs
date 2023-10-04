using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using static ICardType;

public abstract class CardBase : FieldData, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    CardPlace _place = CardPlace.Hand;
    CardState _myState;
    GameObject _playerField;
    FanLayoutGroup _playerHand;
    GameManager _gameManager;
    CardType _type;
    int _attack;
    int _defense = 1;
    int _cost;
    int _playerTotalCost;

    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public int Cost { get => _cost; set => _cost = value; }
    public int PlayerTotalCost => _playerTotalCost;
    public CardType Type => _type; 
    public CardPlace Place => _place;

    public void Start()
    {
        _playerHand = GetComponentInParent<FanLayoutGroup>();
        _gameManager = FindObjectOfType<GameManager>();
        _attack = _myState.Attack;
        _defense = _myState.Defense;
        _cost = _myState.Cost;
        _type = _myState.Type;
    }

    public void Update()
    {
        if(_place == CardPlace.Field)
        {
            PlayAbility(_myState.TriggerAbility);
        }
    }
    public CardState CardState { get => _myState; set => _myState = value; }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _playerField = GetField(eventData, "PlayerField");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // _playerHand = GetField(eventData, "PlayerHand");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_playerField)
        {
            var data = Set();
            _place = CardPlace.Field;
            data.PlayerField.Add(this);
            data.PlayerHand.Remove(this);
            transform.SetParent(_playerField.transform);
            PlayAbility(_myState.SummonAbility);
        }
        else
        {
            transform.SetParent(_playerHand.transform);
        }
    }

    GameObject GetField(PointerEventData eventData, string fieldName)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        RaycastResult result = default;
        foreach(var r in results)
        {
            if(r.gameObject.tag == fieldName)
            {
                result = r;
            }
        }
        return result.gameObject;
    }

    public void PlayAbility(List<IAbility> useAbility)
    {
        if (useAbility != null)
        {
            var data = Set();
            _myState.Target.ForEach(x => x.SetTarget(data));
            if (GameManager.Instance.NowTurn == GameManager.TurnType.Player)
            {
                if (data.PlayerCost >= _cost)
                {
                    Debug.Log("カード使用");
                    if (_myState.Condition.All(x => x.Check(data)))
                    {
                        useAbility.ForEach(x => x.Use(data));
                        data.PlayerCost -= _cost;
                    }
                    transform.SetParent(_playerField.transform);
                }
                else
                {
                    Debug.Log("コストが足りない");
                    transform.SetParent(_playerHand.transform);
                }
            }
            else if (GameManager.Instance.NowTurn == GameManager.TurnType.Enemy)
            {
                if (data.EnemyCost >= _cost)
                {
                    if (_myState.Condition.All(x => x.Check(data)))
                    {
                        useAbility.ForEach(x => x.Use(data));
                        data.EnemyCost -= _cost;
                    }
                    transform.SetParent(_playerField.transform);
                }
                else
                {
                    Debug.Log("コストが足りない");
                    transform.SetParent(_playerHand.transform);
                }
            }
        }
    }
    public enum CardPlace
    {
        Hand,
        Field,
    }


    public abstract void AddDamage(int damage);
}
