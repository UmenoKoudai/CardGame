using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TestAbility : IAbility
{
    public string _debug;
    public void Use(FieldData data)
    {
        //data.TargetData.ForEach(x => Debug.Log(x.CardName));
       Debug.Log($"{_debug}カード使用した");
    }
}
