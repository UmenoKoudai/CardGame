using System;
using Unity.VisualScripting;

[Serializable]
public class AllDamageAbility : IAbility
{
    public int _damage;
    public void Use(FieldData data)
    {

        data.TargetData.ForEach(x => x.AddDamage(_damage));
    }
}
