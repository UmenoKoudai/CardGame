public class PlayerHandTarget : ITarget
{
    public void SetTarget(FieldData data)
    {
        data.TargetData = data.PlayerHand;
    }
}
