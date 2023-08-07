using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostManagement : FieldData
{
    [SerializeField] Target _target;
    [SerializeField] Text _nowCostText;
    [SerializeField] int _nowCost;
    private void Start()
    {
        SetCost(_target, _nowCost);
    }

}
