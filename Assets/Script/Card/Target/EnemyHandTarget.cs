public class EnemyHandTarget : ITarget
{
    public void SetTarget(FieldData data)
    {
        data.TargetData = data.EnemyHand;
    }
}
