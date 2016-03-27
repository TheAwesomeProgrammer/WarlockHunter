using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerstoneXp : MonoBehaviour
{

    public Image powerStoneSprite;
    public Image xPBar;
    private float maxXp = 150;
    private float currentXp;
    private bool canDrainXp = false;
    private Warlock warlock;
    GameObject XpBar;
    Text currentXpValue;
    Color c; 

    void Start()
    {
        warlock = GameObject.FindWithTag("Warlock").GetComponent<Warlock>();
        currentXp = 1;
        xPBar.fillAmount = 0;

        XpBar = GameObject.Find("XpText");
        currentXpValue = XpBar.GetComponent<Text>();

        c = powerStoneSprite.color;
    }

    void Update()
    {

        if (canDrainXp && Input.GetButtonDown("PowerStone") && currentXp > 5)
        { 
            warlock.Xp += (int)Time.deltaTime * 10;
            currentXp -= Time.deltaTime * 10;
        }

        else
        {
            xPBar.fillAmount = currentXp / maxXp;
            currentXp += 2 * Time.deltaTime;           
        }

        if (currentXp > 150) { currentXp = 150; }
        c.a = currentXp / maxXp;
        powerStoneSprite.color = c;
        currentXpValue.text = "XP: " + currentXp.ToString("F0") + " / " + maxXp;
    }

    void OnTriggerEnter2D(Collider2D something)
    {
        if (something.tag == "Warlock")
        {
            canDrainXp = true;
        }
    }

    void OnTriggerStay2D(Collider2D something)
    {
        if (something.tag == "Warlock")
        {
            canDrainXp = true;
        }
    }
    void OnTriggerExit2D(Collider2D something)
    {

        if (something.tag == "Warlock")
        {
            canDrainXp = false;
        }
    }
}
