using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFieldTarget : ITarget
{
    public void SetTarget(FieldData data)
    {
        data.TargetData = data.PlayerField;
    }
}
