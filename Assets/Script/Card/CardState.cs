using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardState
{
    /// <summary> </summary>
    [SerializeField] CardType _cardType = CardType.Character;
    [SerializeField] Sprite _cardImage;
    [SerializeField] int _cost;
    public CardType Type { get { return _cardType; } }


    [SerializeField, SerializeReference, SubclassSelector]
    List<IAbility> _ability = new List<IAbility>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition> _condition = new List<ICondition>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<ITarget> _target = new List<ITarget>();

    public List<IAbility> Ability { get => _ability; set => _ability = value; }
    public List<ICondition> Condition { get => _condition; set => _condition = value; }
    public List<ITarget> Target { get => _target; set => _target = value; }

    public enum CardType
    {
        Character,
        Spell,
    }
}
