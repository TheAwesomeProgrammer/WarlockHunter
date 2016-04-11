
using UnityEngine;
public abstract class CooldownObject : MonoBehaviour
{
    public float Cooldown;

    protected bool _isOnCooldown;

    private float _cooldownTimer = float.MaxValue;

    protected void SetOnCooldown()
    {
        _cooldownTimer = Time.time + Cooldown;
    }

    void Update()
    {
        if (_isOnCooldown && _cooldownTimer <= Time.time)
        {
            _isOnCooldown = false;
        }
    }
}
