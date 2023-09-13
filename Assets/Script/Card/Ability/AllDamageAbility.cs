using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

[Serializable]
public class AllDamageAbility : IAbility
{
    public int _damage;
    public void Use(FieldData data)
    {
        data.TargetData.ForEach(x => UnityEngine.Debug.Log($"{x.CardState.CardName}‚É{_damage}ƒ_ƒ[ƒW"));
        data.TargetData.Where(x => x.CardState.Type == CardState.CardType.Character).ToList().ForEach(x => x.AddDamage(_damage));
    }
}
