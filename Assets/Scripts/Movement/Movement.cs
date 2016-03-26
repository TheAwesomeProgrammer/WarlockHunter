
using UnityEngine;
public abstract class Movement : MonoBehaviour
{
    public MoveState MoveState;

    protected virtual void Start()
    {
        MoveState = MoveState.Move;
    }

    protected virtual void Update()
    {
        if (MoveState == MoveState.Move)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        
    }
}
