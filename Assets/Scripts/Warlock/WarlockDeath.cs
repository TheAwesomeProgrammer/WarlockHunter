using UnityEngine;
using UnityEngine.SceneManagement;

public class WarlockDeath : MonoBehaviour
{
    

    void Start()
    {
        GetComponent<Life>().DeathEvent += OnDeath;
    }

    void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
