using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : ShemObj
{
    [Header("PCButtons")]
    public GameObject Power;
    public Sprite[] PowerBMat;
    //bool isMCARD, isCPU, isGPU, isRAM, isSATA;
    MotherCard MotherCard;

    bool isPowerOn;
    bool isPowerOpen;

    int networkSocets;
    int electricalSocets;
    private void Start()
    {
        base.Start();
        base._OnMouseEnter = COnMouseEnter;
        base._OnMouseDown = OnMD;
        base._OnMouseExit = OnMExit;
        base._OnMouseUp = OnMUP;
        //Debug.Log("Start Computer");
        //Debug.Log(Power.GetComponent<Button>().onClick.ToString());
        //Power.GetComponent<Button>().onClick.AddListener(PowerTrigered);
        //Debug.Log(Power.GetComponent<Button>().onClick.ToString());

        isPowerOn = false;
    }

    public void PowerTrigered()
    {
        isPowerOn = !isPowerOn;
        //Debug.Log("Power" + isPowerOn);
        RevizPowerSprite();
    }

    void RevizPowerSprite()
    {
        if (isPowerOn)
        {
            Power.GetComponent<SpriteRenderer>().sprite = PowerBMat[0];
        }
        else
        {
            Power.GetComponent<SpriteRenderer>().sprite = PowerBMat[1];
        }
    }

    private void COnMouseEnter()
    {
        //Debug.Log("onPCEnter");
    }

    private void OnMD()
    {
        Power.GetComponent<Animator>().SetTrigger("Open");
        isPowerOpen = true;
    }

    private void OnMExit()
    {
        if (isPowerOpen)
        {
            Power.GetComponent<Animator>().SetTrigger("Close");
        }
    }

    private void OnMUP()
    {

    }

}
