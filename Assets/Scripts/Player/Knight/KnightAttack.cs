using UnityEngine;

public class KnightAttack : ActivateObject
{
    public float AnimationDuration = 0.25f;
    public float AttackDuration = 0.25f;

    private XboxInput _xboxInput;
    private bool _attacking;

    protected override void Start()
    {
        base.Start();
        _xboxInput = GetComponent<XboxInput>();
        ActivateTags.Add("Warlock");
        _xboxInput.OnKeyDown += OnKeyDown;
    }

    void OnKeyDown()
    {
        if (!_attacking)
        {
            PlayAnimation();
            Timer.Start(AnimationDuration, gameObject, "StartAttacking");
        }
    }

    void PlayAnimation()
    {
        
    }

    private void StartAttacking()
    {
        _attacking = true;
        Timer.Start(AttackDuration, gameObject, "StopAttacking");
    }

    private void StopAttacking()
    {
        _attacking = false;
    }


}
