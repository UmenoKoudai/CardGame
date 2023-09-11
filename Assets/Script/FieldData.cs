using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldData : MonoBehaviour
{
    static FieldData _instance;
    public static FieldData Instance => _instance;

    List<CardBase> _playerHand = new List<CardBase>();
    List<CardBase> _enemyHand = new List<CardBase>();
    List<CardBase> _playerField = new List<CardBase>();
    List<CardBase> _enemyField = new List<CardBase>();
    List<CardBase> _target = new List<CardBase>();
    int _playerCost;
    int _enemyCost;

    public List<CardBase> PlayerHand { get => _playerHand; set => _playerHand = value; }
    public List<CardBase> EnemyHand { get => _enemyHand; set => _enemyHand = value; }
    public List<CardBase> PlayerField { get => _playerField; set => _playerField = value; }
    public List<CardBase> EnemyField { get => _enemyField; set => _enemyField = value; }
    public List<CardBase> TargetData { get => _target; set => _target = value; }
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
    public void SetTarget(List<CardBase> setCard)
    {
        Instance.TargetData = setCard;
    }

    public void SetHand(Target target, CardBase card)
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

    public void SetField(Target target, CardBase card)
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
