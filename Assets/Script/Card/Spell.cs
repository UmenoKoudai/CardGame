using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : CardBase
{
    [SerializeField] Text _costText;
    void Start()
    {
        
    }

    public void Update()
    {
        _costText.text = base.CardState.Cost.ToString("d2");
        GetComponent<Image>().sprite = base.CardState.CardImage;
    }
}
