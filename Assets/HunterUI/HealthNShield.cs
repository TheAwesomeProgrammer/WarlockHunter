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

    private PlayerProperties _playerProperties;

    void Start()
    {
        _playerProperties = GetComponent<PlayerProperties>();
        TextHp = GameObject.Find("hpText");
        ourHealthComponent = TextHp.GetComponent<Text>();

        TextShield = GameObject.Find("shieldText");
        ourShieldComponent = TextShield.GetComponent<Text>();
    }

    void Update()
    {
        DecreaseShield();
        
        if (_playerProperties.Shield <= 0)
        {
            _playerProperties.Shield = 0;
            DecreaseHealth();
        }
        if (_playerProperties.Health <= 0) { _playerProperties.Health = 0; }
        if (_playerProperties.Shield <= 0) { _playerProperties.Shield = 0; }

        ourHealthComponent.text = _playerProperties.Health.ToString("F0") + " / " + _playerProperties.MaxHealth;
        ourShieldComponent.text = _playerProperties.Shield.ToString("F0") + " / " + _playerProperties.MaxShield;
    }

    void DecreaseHealth()
    {
        _playerProperties.Health -= (int)0.5f;
        float calcHealth = _playerProperties.Health / (float)_playerProperties.MaxHealth;
        SetHealth(calcHealth);
    }

    void SetHealth(float playerHealth)
    {
        HPBar.fillAmount = playerHealth;
    }

    void DecreaseShield()
    {
        _playerProperties.Shield -= (int)0.5f;
        float calcShield = _playerProperties.Shield / (float)_playerProperties.MaxShield;
        SetShield(calcShield);
    }

    void SetShield(float playerShield)
    {
        ShieldBar.fillAmount = playerShield;
    }
}

