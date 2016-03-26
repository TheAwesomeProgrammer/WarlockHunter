
using UnityEngine;
public class WarlockAoe : WarlockAbillity
{
    protected override void PlayAnimation()
    {
        GetComponentInParent<WarlockMovement>().MoveState = MoveState.Stop;
        base.PlayAnimation();
    }

    protected override void UseAbillity()
    {
        GetComponentInParent<WarlockMovement>().MoveState = MoveState.Move;
        base.UseAbillity();
    }
}
