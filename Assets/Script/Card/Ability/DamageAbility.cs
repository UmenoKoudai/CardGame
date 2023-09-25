using System.Linq;
using static ICardType;

public class DamageAbility : IAbility
{
    public int _damage;
    public void Use(FieldData data)
    {
        data.TargetData.Where(x => x.CardState.Type == CardType.Character).ToList().ForEach(x => x.AddDamage(_damage));
    }
}
