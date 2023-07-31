using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICondition
{
    public abstract bool Check(FieldData data);
}