using System;
using UnityEngine;
using UnityEngine.UI;

public class Character : CardBase
{
    [SerializeField] Text _costText;
    [SerializeField] Text _powerText;
    [SerializeField] Text _defenseText;

    public void Update()
    {
        _costText.text = base.CardState.Cost.ToString("d2");
        GetComponent<Image>().sprite = base.CardState.CardImage;
    }
}
