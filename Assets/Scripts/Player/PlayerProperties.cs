using UnityEngine;
[System.Serializable]
public class PlayerProperties
{
    public float Speed;
    public int Health { get; set; }
    public int MaxHealth;
    public float AttackSpeed;
    public int Damage;
    public int Shield;
    public int ControllerNumber;
    public FlippedStart FlippedStart;

    public PlayerProperties(float speed, int health, float attackSpeed, int damage, int shield)
    {
        Speed = speed;
        Health = health;
        AttackSpeed = attackSpeed;
        Damage = damage;
        Shield = shield;
    }
}
