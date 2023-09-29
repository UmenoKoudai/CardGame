using System.Linq;

public class CharacterCheckCondition : ICondition
{
    public bool Check(FieldData data)
    {
        return data.TargetData.Where(x => x.Type == ICardType.CardType.Character).ToList().Count > 0;
    }
}
