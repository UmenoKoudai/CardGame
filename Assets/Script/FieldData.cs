using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldData : MonoBehaviour
{
    static FieldData _instance;
    public static FieldData Instance => _instance;

    List<CardState> _playerHand = new List<CardState>();
    List<CardState> _enemyHand = new List<CardState>();
    List<CardState> _playerField = new List<CardState>();
    List<CardState> _enemyField = new List<CardState>();
    List<CardState> _target = new List<CardState>();
    int _playerCost;
    int _enemyCost;

    public List<CardState> PlayerHand { get => _playerHand; set => _playerHand = value; }
    public List<CardState> EnemyHand { get => _enemyHand; set => _enemyHand = value; }
    public List<CardState> PlayerField { get => _playerField; set => _playerField = value; }
    public List<CardState> EnemyField { get => _enemyField; set => _enemyField = value; }
    public List<CardState> TargetData { get => _target; set => _target = value; }
    public int PlayerCost { get => _playerCost; set => _playerCost = value; }
    public int EnemyCost { get => _enemyCost; set => _enemyCost = value; }

    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public FieldData Set(){return _instance; }
    public void SetTarget(List<CardState> setCard)
    {
        Instance.TargetData = setCard;
    }

    public void SetHand(Target target, CardState card)
    {
        if(target == Target.Player)
        {
            Instance.PlayerHand.Add(card);
        }
        if(target == Target.Enemy)
        {
            Instance.EnemyHand.Add(card);
        }
    }

    public void SetField(Target target, CardState card)
    {
        if (target == Target.Player)
        {
            Instance.PlayerField.Add(card);
        }
        if (target == Target.Enemy)
        {
            Instance.EnemyField.Add(card);
        }
    }

    public void SetCost(Target target, int cost)
    {
        if(target == Target.Player)
        {
            Instance.PlayerCost = cost;
        }
        if(target == Target.Enemy)
        {
            Instance.EnemyCost = cost;
        }
    }

    public enum Target
    {
        Player,
        Enemy,
    }
}
