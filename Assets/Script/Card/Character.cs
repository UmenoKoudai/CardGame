using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Character : CardBase
{
    [SerializeField] Text _costText;
    [SerializeField] Text _powerText;
    [SerializeField] Text _defenseText;
    Sprite _cardImage;
    Image _myImage;
    int _attack;
    int _cost;
    int _defense;

    private void Start()
    {
        base.Start();
        _myImage = GetComponent<Image>();
        _cardImage = CardState.CardImage;
        _attack = CardState.Attack;
        _cost = CardState.Cost;
        _defense = CardState.Defense;
    }

    public void Update()
    {
        _costText.text = _cost.ToString("d2");
        _myImage.sprite = _cardImage;
        _powerText.text = _attack.ToString("d2");
        _defenseText.text = _defense.ToString("d2");
        if (_defense <= 0)
        {
            Destroy(gameObject);
        }
        if (Place == CardPlace.Field)
        {
            Debug.Log($"{CardState.CardName}はフィールドにいる");
            //PlayAbility(CardState.TriggerAbility);
        }
    }


    public override void AddDamage(int damage)
    {
        Debug.Log($"今のHP{_defense}");
        _defense -= damage;
    }

}
