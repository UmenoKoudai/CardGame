public class EnemyFieldTarget : ITarget
{
    public void SetTarget(FieldData data)
    {
        data.TargetData = data.EnemyField;
    }
}
