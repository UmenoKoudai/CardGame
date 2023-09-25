using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static ICardType;

[Serializable]
public class CardState
{
    [SerializeField] string _cardName;
    [SerializeField] CardType _cardType = CardType.Character;
    [SerializeField] Sprite _cardImage;
    [SerializeField] int _cost;
    [SerializeField] int _attack;
    [SerializeField] int _defense;

    [SerializeField, SerializeReference, SubclassSelector]
    List<IAbility> _ability = new List<IAbility>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition> _condition = new List<ICondition>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<ITarget> _target = new List<ITarget>();

    public Sprite CardImage => _cardImage;
    public CardType Type => _cardType;
    public int Cost => _cost;
    public int Attack => _attack;
    public int Defense => _defense;
    public string CardName => _cardName;
    public List<IAbility> Ability { get => _ability; set => _ability = value; }
    public List<ICondition> Condition { get => _condition; set => _condition = value; }
    public List<ITarget> Target { get => _target; set => _target = value; }

    public CardState(string name, int cost, int attack, int defense, Sprite cardImage, CardType type, List<IAbility> ability, List<ICondition> condition, List<ITarget> target)
    {
        _cardName = name;
        _attack = attack;
        _defense = defense;
        _cost = cost;
        _cardImage = cardImage;
        _cardType = type;
        _ability = ability;
        _condition = condition;
        _target = target;
    }
}
