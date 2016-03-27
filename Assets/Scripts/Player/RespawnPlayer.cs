
using UnityEngine;
public class RespawnPlayer : MonoBehaviour
{
    public GameObject Player;

    public float RespawnTime;

    private Vector2 _spawnPosition;

    public void SpawnAfterTime(Vector2 positon)
    {
        _spawnPosition = positon;
        Timer.Start(RespawnTime, gameObject, "Spawn");
    }

    private void Spawn()
    {
        GameObject player = Instantiate(Player, _spawnPosition, Quaternion.identity) as GameObject;
        player.transform.parent = transform;
    }
}
