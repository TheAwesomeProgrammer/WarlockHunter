using UnityEngine;


public class WarlockAbillity : CooldownObject
{
    public string ButtonName;
    public float AnimationTime;
    public WarlockAbillityProperties WarlockAbillityProperties;
    public GameObject DamageObject;

    protected virtual void Update()
    {
        ShouldUseAbillity();
    }

    protected virtual void ShouldUseAbillity()
    {
        if (Input.GetButtonDown(ButtonName) && !_isOnCooldown)
        {
            PlayAnimation();
            Timer.Start(AnimationTime, gameObject, "UseAbillity");
        }
    }

    protected virtual void PlayAnimation()
    {
        
    }

    protected virtual void UseAbillity()
    {
        SetOnCooldown();
        SetPropertiesOnObject(SpawnDamageObject());
    }

    protected virtual GameObject SpawnDamageObject()
    {
        return Instantiate(DamageObject, transform.position, Quaternion.identity) as GameObject;
    }

    protected virtual void SetPropertiesOnObject(GameObject spawnedObject)
    {
        WarlockAbillityDamager warlockAbillityDamager = spawnedObject.GetComponent<WarlockAbillityDamager>();
        warlockAbillityDamager.Damage = WarlockAbillityProperties.Damage;
        Destroy(spawnedObject, WarlockAbillityProperties.Duration);
    }
}
