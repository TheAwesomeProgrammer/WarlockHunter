
using System.Collections.Generic;
using UnityEngine;

public class LifePotion : Potion
{
    public float CycleInterval = 1;
    public float Duration = 3;

    protected List<Life> _healingObjects;

    private float _changeLifeTimer;
    private float _endChangeLifeTimer;
    private bool _changeLife;
    private Animator _animator;

    protected override void Start()
    {
        base.Start();
        ActivateTags.Add("Warlock");
        DeactivateTags.Add("Warlock");
        _healingObjects = new List<Life>();
        _animator = GetComponent<Animator>();
        _endChangeLifeTimer = float.MaxValue;
    }

    public override void Activate(GameObject otherObject)
    {
        base.Activate(otherObject);
        if (_healingObjects.Contains(otherObject.GetComponent<Life>()) || _healingObjects.Count <= 0  )
        {
            _healingObjects.Add(otherObject.GetComponent<Life>());
        }
    }

    public override void Deactivate(GameObject otherObject)
    {
        base.Deactivate(otherObject);
        if (_healingObjects.Contains(otherObject.GetComponent<Life>()) || _healingObjects.Count <= 0)
        {
            _healingObjects.Remove(otherObject.GetComponent<Life>());
        }
    }

    protected override void ActivatePotion()
    {
        base.ActivatePotion();
        _changeLife = true;
        _endChangeLifeTimer = Time.time + Duration;
    }

    protected override void Update()
    {
        base.Update();
        ShouldChangeLife();
    }

    protected virtual void ShouldChangeLife()
    {
        if (_changeLifeTimer <= Time.time && _changeLife)
        {
            ChangeLife();
        }
        else if (_endChangeLifeTimer <= Time.time && _changeLife)
        {
            Destroy(gameObject);
        }
    }

   protected virtual void ChangeLife()
   {
       _changeLifeTimer = Time.time + CycleInterval;
        _animator.Play("Potion");
   }
}
