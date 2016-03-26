using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Shot : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public List<string> DamagingTags { get; set; }
    public List<string> KillingTags { get; set; }

    void Start()
    {
        DamagingTags = new List<string>();
        KillingTags = new List<string>();
        DamagingTags.Add("Player");       
    }

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (DamagingTags.Contains(otherCollider.tag))
        {
            otherCollider.GetComponent<Life>().Health -= Damage;
            Destroy(gameObject);
        }

        if (KillingTags.Contains(otherCollider.tag))
        {
            Destroy(gameObject);
        }

    }
}
