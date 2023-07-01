using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CardState
{
    [SerializeField] CardType _cardType = CardType.Character;
    [SerializeField] Sprite _cardImage;
    [SerializeField] int _cost;

    enum CardType
    {
        Character,
        Spell,
    }
}
