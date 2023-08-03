using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAbility : IAbility
{
    public void Use(FieldData data)
    {
        data.TargetData.ForEach(x => Debug.Log(x));
        Debug.Log("カード使用した");
    }
}
