using UnityEngine;


public class WarlockAbillity : MonoBehaviour
{
    public string ButtonName;
    public float AnimationTime;
    public WarlockAbillityProperties WarlockAbillityProperties;
    public GameObject DamageObject;

    protected float AbillityTimer;

    protected virtual void Update()
    {
        ShouldUseAbillity();
    }

    protected virtual void ShouldUseAbillity()
    {
        if (Input.GetButtonDown(ButtonName) && AbillityTimer <= Time.time)
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
        SetCooldown();
        SetPropertiesOnObject(SpawnDamageObject());
    }

    protected virtual void SetCooldown()
    {
        AbillityTimer = Time.time + WarlockAbillityProperties.Cooldown;
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
