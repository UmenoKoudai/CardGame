using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : ITarget
{
    public void SetTarget(FieldData data)
    {
        int random = Random.Range(0, data.TargetData.Count);
        List<CardBase> currentTarget = new List<CardBase>() { data.TargetData[random] };
        data.TargetData = currentTarget;
    }
}
