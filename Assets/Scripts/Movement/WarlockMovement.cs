using System.Collections.Generic;
using UnityEngine;


public class WarlockMovement : Movement
{
    private Dictionary<string, Vector2> _directionSets = new Dictionary<string, Vector2>()
    {
        {"Up", Vector2.up},
        {"Down", Vector2.down},
        {"Left", Vector2.left},
        {"Right", Vector2.right}
    };

    private Collision _collision;
    private Collider2D _collider2D;
    private PlayerProperties _playerProperties;

    protected override void Start()
    {
        base.Start();
        _playerProperties = GetComponent<Player>().PlayerProperties;
        _collision = GetComponentInChildren<Collision>();
        _collider2D = transform.FindChildByTag("PlayerCollision").GetComponent<Collider2D>();
    }



    protected override void Move()
    {
        base.Move();
        Vector2 velocity = Vector2.zero;

        foreach (var directionSet in _directionSets)
        {
            if (Input.GetButton(directionSet.Key))
            {
                velocity += directionSet.Value;
            }
        }

        velocity.Normalize();
        velocity *= _playerProperties.Speed * Time.deltaTime;

     Vector2 allowedPosition = _collision.GetAllowedPosition(transform.position, (Vector2) transform.position + velocity,
            _collider2D.bounds.extents, gameObject);

        transform.Translate((allowedPosition - (Vector2)transform.position), Space.World);
    }
}
