using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cooldowns : MonoBehaviour
{

    public Image Bbtn;
    public float Cd = 3f;
    public float currentCd;
    public bool DecreaseCD;

    GameObject TextABtn;
    Text ourABtn;

    void Start()
    {
        TextABtn = GameObject.Find("CdAText");
        ourABtn = TextABtn.GetComponent<Text>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && !DecreaseCD)
        {
            Bbtn.fillAmount = 360;
            currentCd = Cd;
            DecreaseCD = true;
        }

        if (DecreaseCD)
        {
            Bbtn.fillAmount -= 1f / Cd * Time.deltaTime;
            currentCd -= Time.deltaTime;
            ourABtn.text = currentCd.ToString("F0");

            if (currentCd <= 0)
            {
                DecreaseCD = false;
            }
        }

        else
        {

            Bbtn.fillAmount = 0;
            ourABtn.text = "";
            Cd = 3;
        }
    }
}
