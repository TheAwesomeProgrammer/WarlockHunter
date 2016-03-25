using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image HPBar;
    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;


    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        DecreaseHealth();
    }

    void DecreaseHealth()
    {
        CurrentHealth -= 0.5f;
        float calcHealth = CurrentHealth / MaxHealth;
        SetHealth(calcHealth);
    }

    void SetHealth(float playerHealth)
    {
        HPBar.fillAmount = playerHealth;
    }
}
