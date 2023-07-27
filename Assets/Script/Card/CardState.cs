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

    [SerializeField, SerializeReference, SubclassSelector]
    List<IAbility> _ability = new List<IAbility>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition> _condition = new List<ICondition>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<ITarget> _target = new List<ITarget>();

    enum CardType
    {
        Character,
        Spell,
    }
}
