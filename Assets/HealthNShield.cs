using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthNShield : MonoBehaviour
{

    public Image HPBar;
    public Image ShieldBar;
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float MaxShield = 200f;
    public float CurrentShield;

    GameObject TextHp;
    Text ourHealthComponent;

    GameObject TextShield;
    Text ourShieldComponent;

    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentShield = MaxShield;

        TextHp = GameObject.Find("hpText");
        ourHealthComponent = TextHp.GetComponent<Text>();

        TextShield = GameObject.Find("shieldText");
        ourShieldComponent = TextShield.GetComponent<Text>();
    }

    void Update()
    {
        DecreaseShield();

        if(CurrentShield <= 0)
        {
            CurrentShield = 0;
            DecreaseHealth();
        }

        if(CurrentHealth <= 0) { CurrentHealth = 0; }
        if (CurrentShield <= 0) { CurrentShield = 0; }

        ourHealthComponent.text = CurrentHealth.ToString("F0") + " / " + MaxHealth;
        ourShieldComponent.text = CurrentShield.ToString("F0") + " / " + MaxShield;
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

    void DecreaseShield()
    {
        CurrentShield -= 0.5f;
        float calcShield = CurrentShield / MaxShield;
        SetShield(calcShield);
    }

    void SetShield(float playerShield)
    {
        ShieldBar.fillAmount = playerShield;
    }
}

