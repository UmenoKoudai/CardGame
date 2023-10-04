using UnityEngine;
using UnityEngine.UI;

public class Spell : CardBase
{
    [SerializeField] Text _costText;
    Image _mySprite;
    private void Awake()
    {
        _mySprite = GetComponent<Image>();
    }
    public void Update()
    {
        _costText.text = CardState.Cost.ToString("d2");
        _mySprite.sprite = CardState.CardImage;
        if (Place == CardPlace.Field)
        {
            PlayAbility(CardState.TriggerAbility);
        }
    }

    public override void AddDamage(int damage)
    {
        Debug.LogError("Spellカードにはこの効果を使用できません");
    }
}
