using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAbility : IAbility
{
    public void Use(FieldData data)
    {
        Debug.Log($"HandCount:{data.PlayerHand.Count}");
        Debug.Log($"FieldCount:{data.PlayerField.Count}");
        data.TargetData.ForEach(x => Debug.Log(x));
        Debug.Log("カード使用した");
    }
}
