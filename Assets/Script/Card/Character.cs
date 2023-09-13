using System;
using UnityEngine;
using UnityEngine.UI;

public class Character : CardBase
{
    [SerializeField] Text _costText;
    [SerializeField] Text _powerText;
    [SerializeField] Text _defenseText;
    Sprite _cardImage;
    int _attack;
    int _cost;
    int _defense;

    private void OnEnable()
    {
        //SetHand(Target.Player, this);
    }

    private void Start()
    {
        _cardImage = CardState.CardImage;
        _attack = CardState.Attack;
        _cost = CardState.Cost;
        _defense = CardState.Defense;
    }

    public void Update()
    {
        _costText.text = _cost.ToString("d2");
        GetComponent<Image>().sprite = _cardImage;
        _powerText.text = _attack.ToString("d2");
        _defenseText.text = _defense.ToString("d2");
        if (_defense <= 0)
        {
            Destroy(gameObject);
        }
    }


    public override void AddDamage(int damage)
    {
        Debug.Log($"¡‚ÌHP{_defense}");
        _defense -= damage;
    }

}
