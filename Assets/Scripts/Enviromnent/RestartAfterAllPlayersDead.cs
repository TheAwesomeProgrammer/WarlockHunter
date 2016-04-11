using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAfterAllPlayersDead : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
