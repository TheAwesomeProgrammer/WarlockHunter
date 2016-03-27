
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Potion : ActivateObject
{
    protected Shot _shot;
    protected bool _hasActivated;

    protected override void Start()
    {
        base.Start();
        _shot = GetComponent<Shot>();
    }

    protected virtual void Update()
    {
        ShouldActivatePotion();
    }

    protected virtual void ShouldActivatePotion()
    {
        if (_shot.Speed <= 0.1f && !_hasActivated)
        {
            ActivatePotion();
            _hasActivated = true;
        }
    }

    protected virtual void ActivatePotion()
    {
        
    }
}
