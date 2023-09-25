using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICardType
{
    public enum CardType
    {
        Character,
        Spell,
        None,
    }
}
