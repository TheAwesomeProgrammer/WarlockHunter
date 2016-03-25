using UnityEngine;


[System.Serializable]
public class PlayerProperites
{
    public float Speed;
    public int Health;
    public float AttackSpeed;
    public float Damage;
    public int Shield;
    public int Xp;

    public PlayerProperites(float speed, int health, float attackSpeed, float damage, int shield, int xp)
    {
        Speed = speed;
        Health = health;
        AttackSpeed = attackSpeed;
        Damage = damage;
        Shield = shield;
        Xp = xp;
    }
}
