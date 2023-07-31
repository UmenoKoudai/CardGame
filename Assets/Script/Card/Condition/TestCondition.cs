using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCondition : ICondition
{
    public bool Check(FieldData data)
    {
        return true;
    }
}
