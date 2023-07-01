using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldData : MonoBehaviour
{
    List<CardState> _playerHand = new List<CardState>();
    List<CardState> _enemyHand = new List<CardState>();
    List<CardState> _playerField = new List<CardState>();
    List<CardState> _enemyField = new List<CardState>();

    public void SetHand(Target target, CardState card)
    {
        if(target == Target.Player)
        {
            _playerHand.Add(card);
        }
        if(target == Target.Enemy)
        {
            _enemyHand.Add(card);
        }
    }

    public void SetField(Target target, CardState card)
    {
        if (target == Target.Player)
        {
            _playerField.Add(card);
        }
        if (target == Target.Enemy)
        {
            _enemyField.Add(card);
        }
    }

    public enum Target
    {
        Player,
        Enemy,
    }
}
