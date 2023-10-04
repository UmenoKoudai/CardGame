using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPlayCondition : ICondition
{
    public bool Check(FieldData data)
    {
        return data.TargetData[data.TargetData.Count - 1].CardState.Type == ICardType.CardType.Spell;
    }
}
