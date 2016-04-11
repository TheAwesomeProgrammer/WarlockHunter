
using UnityEngine;
public class PlayerDead : MonoBehaviour
{
    public GameObject DeadObject;

    void Start()
    {
        GetComponent<Life>().DeathEvent += OnDeath;
    }

    void OnDeath()
    {
        Instantiate(DeadObject, transform.position, Quaternion.identity);
        GetComponentInParent<RespawnPlayer>().SpawnAfterTime(transform.position);
    }
}
