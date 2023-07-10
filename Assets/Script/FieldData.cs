using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldData : MonoBehaviour
{
    FieldData _instance;
    public FieldData Instance => _instance;

    List<CardState> _playerHand = new List<CardState>();
    List<CardState> _enemyHand = new List<CardState>();
    List<CardState> _playerField = new List<CardState>();
    List<CardState> _enemyField = new List<CardState>();
    List<CardState> _target = new List<CardState>();

    public List<CardState> PlayerHand { get => _playerHand; set => _playerHand = value; }
    public List<CardState> EnemyHand { get => _enemyHand; set => _enemyHand = value; }
    public List<CardState> PlayerField { get => _playerField; set => _playerField = value; }
    public List<CardState> EnemyField { get => _enemyField; set => _enemyField = value; }
    public List<CardState> TargetData { get => _target; set => _target = value; }

    protected void Awake(){ _instance = this;}
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

    public enum Target
    {
        Player,
        Enemy,
    }
}
