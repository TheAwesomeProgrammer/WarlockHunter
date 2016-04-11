using UnityEngine;


public class WarlockShoot : WarlockAbillity
{
    public Transform SpawnTransform;

    protected override GameObject SpawnDamageObject()
    {
        return Instantiate(DamageObject, SpawnTransform.position,
            Quaternion.Euler(new Vector3(0, 0, GetDirectionToMouse().GetAngleBasedOnDirection()))) as GameObject;
    }

    protected override void SetPropertiesOnObject(GameObject spawnedObject)
    {
        spawnedObject.GetComponent<Shot>().Damage = WarlockAbillityProperties.Damage;
    }

    private Vector2 GetDirectionToMouse()
    {
        Vector2 mouseInWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mouseInWorldPoint - (Vector2)transform.position).normalized;
    }
}
