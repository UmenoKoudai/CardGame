using System;
using UnityEngine;
using UnityEngine.UI;

public class Character : CardBase
{
    [SerializeField] Text _costText;
    [SerializeField] Text _powerText;
    [SerializeField] Text _defenseText;
    int _defense;
    int _power;
    int _cost;

    public int Defense => _defense;
    private void Start()
    {
        _defense = CardState.Defense;
        _power = CardState.Attack;
        _cost = CardState.Cost;
    }

    public void Update()
    {
        _costText.text = base.CardState.Cost.ToString("d2");
        GetComponent<Image>().sprite = base.CardState.CardImage;
        _powerText.text = base.CardState.Attack.ToString("d2");
        _defenseText.text = base.CardState.Defense.ToString("d2");
        if(base.CardState.Defense <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void AddDamage(int damage)
    {

    }
}
