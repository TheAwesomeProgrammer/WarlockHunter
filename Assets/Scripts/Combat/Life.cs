using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject DeadObject;

    private PlayerProperties _playerProperties;

    public int Health
    {
        get{ return _playerProperties.Health; }

        set { _playerProperties.Health = (int)Mathf.Clamp(value, 0, _playerProperties.MaxHealth); }
    }

    void Start()
    {
        _playerProperties = GetComponent<Player>().PlayerProperties;
        Health = _playerProperties.MaxHealth;
    }

    void Update()
    {
        ShouldDie();
    }

    void ShouldDie()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(DeadObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    


}
