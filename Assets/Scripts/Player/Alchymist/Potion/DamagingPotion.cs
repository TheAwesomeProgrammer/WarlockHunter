
public class DamagingPotion : LifePotion
{
    public int DamagePerCycle = 4;
    public int DamageDownPerCycle = 1;

    protected override void ChangeLife()
    {
        base.ChangeLife();
        foreach (var healingObject in _healingObjects)
        {
            healingObject.Health -= DamagePerCycle;
        }

        DamageDownPerCycle -= DamageDownPerCycle;
    }
}
