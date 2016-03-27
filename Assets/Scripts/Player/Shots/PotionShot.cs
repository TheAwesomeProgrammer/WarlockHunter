
using UnityEngine;

public class PotionShot : Shot
{
    private Collision _collision;

    protected override void Start()
    {
        base.Start();
        DamagingTags.Clear();
        _collision = GetComponent<Collision>();
    }

    protected override void Move()
    {
        
        Vector2 velocity = (transform.eulerAngles.z - 90).GetDirectionBasedOnAngle() * Speed * Time.deltaTime;
        Vector2 allowedPosition = _collision.GetAllowedPosition(transform.position, (Vector2)transform.position + velocity,
            GetComponent<Collider2D>().bounds.extents, gameObject); 

        transform.Translate((allowedPosition - (Vector2)transform.position), Space.World);
    }
}
