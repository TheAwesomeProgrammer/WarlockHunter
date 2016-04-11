using UnityEngine;
[System.Serializable]
public class PlayerProperties
{
    public float Speed;
    public int MaxHealth;
    public int StartHealth = 3;
    public float AttackSpeed;
    public int Damage;
    public int Shield;
    public int MaxShield;
    public int ControllerNumber;
    public FlippedStart FlippedStart;

    public PlayerProperties(float speed, int health, float attackSpeed, int damage, int shield)
    {
        Speed = speed;
        StartHealth = health;
        AttackSpeed = attackSpeed;
        Damage = damage;
        Shield = shield;
    }
}
