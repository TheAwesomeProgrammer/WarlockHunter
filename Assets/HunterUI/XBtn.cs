using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XBtn : MonoBehaviour {
    public Image Xbtn;
    public float Cd = 30f;
    public float currentCd;
    public bool DecreaseCD;

    GameObject TextXBtn;
    Text ourXBtn;

    void Start()
    {
        TextXBtn = GameObject.Find("CdXText");
        ourXBtn = TextXBtn.GetComponent<Text>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D) && !DecreaseCD)
        {
 
            Xbtn.fillAmount = 360;
            currentCd = Cd;
            DecreaseCD = true;
        }

        if (DecreaseCD)
        {
            Xbtn.fillAmount -= 1f / Cd * Time.deltaTime;
            currentCd -= Time.deltaTime;
            ourXBtn.text = currentCd.ToString("F0");

            if (currentCd <= 0)
            {
                DecreaseCD = false;
            }
        }

        else
        {

            Xbtn.fillAmount = 0;
            ourXBtn.text = "";
            Cd = 30;
        }
    }
}
