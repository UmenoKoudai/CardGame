using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBase : FieldData, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    CardState _myState;
    GameObject _playerField;
    GameManager _gameManager;
    int _attack;
    int _defense;
    int _cost;
    int _playerTotalCost;

    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public int Cost { get => _cost; set => _cost = value; }
    public int PlayerTotalCost => _playerTotalCost;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _attack = _myState.Attack;
        _defense = _myState.Defense;
        _cost = _myState.Cost;
        _playerTotalCost = _gameManager.PlayerTotalCost;
    }
    public CardState CardState { get => _myState; set => _myState = value; }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _playerField = GetField(eventData);
        //if (_playerField)
        //{
        //    Debug.Log($"{_playerField.name}の上にいます");
        //}
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
        if(_myState.Condition.All(x => x.Check(data)))
        {
            _myState.Ability.ForEach(x => x.Use(data));
        }
    }

    public virtual void AddDamage(int damage)
    {
        Debug.LogError("派生クラスでオーバーロードしていません");
    }
}
