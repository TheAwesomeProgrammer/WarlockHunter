using UnityEngine;

namespace Assets.Scripts.Level_system
{
    [System.Serializable]
    public class PlayerProperites
    {
        public float Speed;
        public int Health;
        public float AttackSpeed;
        public float Damage;

        public PlayerProperites(float speed, int health, float attackSpeed, float damage)
        {
            Speed = speed;
            Health = health;
            AttackSpeed = attackSpeed;
            Damage = damage;
        }
    }
}