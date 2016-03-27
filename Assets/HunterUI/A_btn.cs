using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class A_btn : MonoBehaviour {

    public Image Abtn;
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
            Abtn.fillAmount = 360;
            currentCd = Cd;
            DecreaseCD = true;
        }

        if (DecreaseCD)
        {
            Abtn.fillAmount -= 1f / Cd * Time.deltaTime;
            currentCd -= Time.deltaTime;
            ourABtn.text = currentCd.ToString("F0");

            if (currentCd <= 0)
            {
                DecreaseCD = false;
            }
        }

        else
        {

            Abtn.fillAmount = 0;
            ourABtn.text = "";
            Cd = 3;
        }
    }
}
