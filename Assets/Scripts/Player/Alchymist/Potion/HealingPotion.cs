
public class HealingPotion : LifePotion
{
    public int HealingPerCycle = 4;
    public int HealingDownPerCycle = 1;

    protected override void ChangeLife()
    {
        base.ChangeLife();
        foreach (var healingObject in _healingObjects)
        {
            healingObject.Health += HealingPerCycle;
        }

        HealingPerCycle -= HealingDownPerCycle;
    }
}
