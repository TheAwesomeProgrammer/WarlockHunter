using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    public event Action DeathEvent;
    public int StartHealth = 3;
    public int MaxHealth = 3;
    public int Shield = 0;
    public int MaxShield = 0;

    private int _health;

    public int Health
    {
        get{ return _health; }

        set { _health = (int)Mathf.Clamp(value, 0, MaxHealth); }
    }

    void Awake()
    {
        Health = StartHealth;
    }

    public void SetHealth(PlayerProperties playerProperties)
    {
        MaxHealth = playerProperties.MaxHealth;
        Health = playerProperties.StartHealth;
        Shield = playerProperties.Shield;
        MaxShield = playerProperties.MaxShield;
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
        if (DeathEvent != null)
        {
            DeathEvent();
        }
        Destroy(gameObject);
    }
    


}
