using System.Linq;

public class SpellCheckCondition : ICondition
{
    public bool Check(FieldData data)
    {
        return data.TargetData.Where(x => x.Type == ICardType.CardType.Spell).ToList().Count > 0;
    }
}
