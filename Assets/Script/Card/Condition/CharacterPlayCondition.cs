public class CharacterPlayCondition : ICondition
{
    public bool Check(FieldData data)
    {
        return data.TargetData[data.TargetData.Count - 1].CardState.Type == ICardType.CardType.Character;
    }
}
