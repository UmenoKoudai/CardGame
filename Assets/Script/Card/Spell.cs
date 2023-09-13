using UnityEngine;
using UnityEngine.UI;

public class Spell : CardBase
{
    [SerializeField] Text _costText;

    public void Update()
    {
        _costText.text = base.CardState.Cost.ToString("d2");
        GetComponent<Image>().sprite = base.CardState.CardImage;
    }

    public override void AddDamage(int damage)
    {
        Debug.LogError("Spellカードにはこの効果を使用できません");
    }
}
