

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WarlockAbillityDamager : ActivateObject
{
    public int Damage { get; set; }

    protected List<GameObject> _objectsDoneDamageTo;

    protected override void Start()
    {
        base.Start();
        _objectsDoneDamageTo = new List<GameObject>();
    }

    public override void Activate(GameObject otherObject)
    {
        base.Activate(otherObject);
        DoDamageToPlayer(otherObject);
    }

    protected virtual void DoDamageToPlayer(GameObject objectToDamage)
    {
        if (!_objectsDoneDamageTo.Contains(objectToDamage))
        {
            _objectsDoneDamageTo.Add(objectToDamage);
            objectToDamage.GetComponent<Life>().Health -= Damage;
        }
    }
}
