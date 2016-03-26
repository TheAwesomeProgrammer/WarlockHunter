using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BBtn : MonoBehaviour {

    public Image Bbtn;
    public float Cd = 60f;
    public float currentCd;
    public bool DecreaseCD;

    GameObject TextBBtn;
    Text ourBBtn;

	void Start ()
    {
        TextBBtn = GameObject.Find("CdBText");
        ourBBtn = TextBBtn.GetComponent<Text>();
	}
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.S) && !DecreaseCD)
        {
            // Place ward 
            Bbtn.fillAmount = 360;
            currentCd = Cd;
            DecreaseCD = true;
        }

        if(DecreaseCD)
        {
            Bbtn.fillAmount -= 1f / Cd * Time.deltaTime; 
            currentCd -= Time.deltaTime;
            ourBBtn.text = currentCd.ToString("F0");

            if(currentCd <= 0)
            {   
                DecreaseCD = false;
            }
        }

        else
        {
            
            Bbtn.fillAmount = 0;
            ourBBtn.text = "";
            Cd = 60;
        }
    }
}
