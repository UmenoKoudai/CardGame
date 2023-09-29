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
    GameManager _gameManager;
    CardType _type;
    int _attack;
    int _defense = 1;
    int _cost;
    int _playerTotalCost;
    Transform _handPosition;

    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public int Cost { get => _cost; set => _cost = value; }
    public int PlayerTotalCost => _playerTotalCost;
    public CardType Type => _type; 

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _attack = _myState.Attack;
        _defense = _myState.Defense;
        _cost = _myState.Cost;
        _type = _myState.Type;
        _handPosition = GetComponentInParent<Transform>();
    }
    private void Update()
    {
        if(_place == CardPlace.Field)
        {
            PlayAbility();
        }
    }
    public CardState CardState { get => _myState; set => _myState = value; }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _playerField = GetField(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("カード選択中");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_playerField)
        {
            var data = Set();
            data.PlayerField.Add(this);
            data.PlayerHand.Remove(this);
            transform.SetParent(_playerField.transform);
            PlayAbility();
        }
    }

    GameObject GetField(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        RaycastResult result = default;
        foreach(var r in results)
        {
            if(r.gameObject.tag == "PlayerField")
            {
                result = r;
            }
        }
        return result.gameObject;
    }

    public void PlayAbility()
    {
        var data = Set();
        _myState.Target.ForEach(x => x.SetTarget(data));
        if (GameManager.Instance.NowTurn == GameManager.TurnType.Player && PlayerCost >= _cost)
        {
            if (_myState.Condition.All(x => x.Check(data)))
            {
                _myState.Ability.ForEach(x => x.Use(data));
                PlayerCost -= _cost;
            }
        }
        else
        {
            Debug.Log("コストが足りない");
            transform.SetParent(_handPosition);
        }
        if (GameManager.Instance.NowTurn == GameManager.TurnType.Enemy && EnemyCost >= _cost)
        {
            if (_myState.Condition.All(x => x.Check(data)))
            {
                _myState.Ability.ForEach(x => x.Use(data));
                EnemyCost -= _cost;
            }
        }
        else
        {
            Debug.Log("コストが足りない");
            transform.SetParent(_handPosition);
        }
        if (_myState.Condition.All(x => x.Check(data)))
        {
            _myState.Ability.ForEach(x => x.Use(data));
            EnemyCost -= _cost;
        }
    }
    public enum CardPlace
    {
        Hand,
        Field,
    }


    public abstract void AddDamage(int damage);
}
