using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthNShield : MonoBehaviour
{
    public Image HPBar;
    public Image ShieldBar;

    GameObject TextHp;
    Text ourHealthComponent;

    GameObject TextShield;
    Text ourShieldComponent;

    private Life _life;

    void Start()
    {
        _life = GetComponent<Life>();
        TextHp = GameObject.Find("hpText");
        ourHealthComponent = TextHp.GetComponent<Text>();

        TextShield = GameObject.Find("shieldText");
        ourShieldComponent = TextShield.GetComponent<Text>();
    }

    void Update()
    {
        DecreaseShield();
        
        if (_life.Shield <= 0)
        {
            _life.Shield = 0;
            DecreaseHealth();
        }
        if (_life.Health <= 0) { _life.Health = 0; }
        if (_life.Shield <= 0) { _life.Shield = 0; }

        ourHealthComponent.text = _life.Health.ToString("F0") + " / " + _life.MaxHealth;
        ourShieldComponent.text = _life.Shield.ToString("F0") + " / " + _life.MaxShield;
    }

    void DecreaseHealth()
    {
        _life.Health -= (int)0.5f;
        float calcHealth = _life.Health / (float)_life.MaxHealth;
        SetHealth(calcHealth);
    }

    void SetHealth(float playerHealth)
    {
        HPBar.fillAmount = playerHealth;
    }

    void DecreaseShield()
    {
        _life.Shield -= (int)0.5f;
        float calcShield = _life.Shield / (float)_life.MaxShield;
        SetShield(calcShield);
    }

    void SetShield(float playerShield)
    {
        ShieldBar.fillAmount = playerShield;
    }
}

