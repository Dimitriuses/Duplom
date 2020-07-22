using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Computer : ShemObj
{
    [Header("PCButtons")]
    public GameObject Power;
    public UnityEngine.UI.Button[] UserB;
    public Sprite[] PowerBMat;
    public CircleCollider2D UseColiider;
    public CircleCollider2D EditCollider;
    public int RValue;
    public float PValue;
    public float Radius;

    [Header("Computer")]
    public Sprite[] PCMaterials;
    
    //bool isMCARD, isCPU, isGPU, isRAM, isSATA;
    MotherCard MotherCard;

    bool isPowerOn;
    bool isPowerOpen;
    bool isButtonLock;

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
            GetComponent<SpriteRenderer>().sprite = PCMaterials[0];
        }
        else
        {
            Power.GetComponent<SpriteRenderer>().sprite = PowerBMat[1];
            GetComponent<SpriteRenderer>().sprite = PCMaterials[1];
        }
    }

    private void COnMouseEnter()
    {
        //Debug.Log("onPCEnter");
        isButtonLock = true;
    }

    private void OnMD()
    {
        if (!isPowerOpen && Locked)
        {
            Power.GetComponent<Animator>().SetBool("isOpen", true);
            //Power.GetComponent<Animator>();
            isPowerOpen = true;
        }

    }

    private void OnMExit()
    {
        isButtonLock = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (isPowerOpen && !isButtonLock)
        {
            Power.GetComponent<Animator>().SetBool("isOpen", false);
            isPowerOpen = false;
        }
    }

    private void OnMUP()
    {

    }

    void ButtonPosChange(UnityEngine.UI.Button button, float rotateVaule)
    {
        float ammount = (PValue / 100) * rotateVaule / RValue;
        float BRV = ammount * 360;
        button.GetComponent<RectTransform>().position = new Vector3((float)Math.Cos(BRV)*Radius, (float)Math.Sin(BRV)*Radius, 0);
        Debug.Log(BRV + " cos=" + Math.Cos(BRV) + "; sin=" + ConvertRadiansToDegrees(Math.Sin(BRV)));
    }

    private void Update()
    {
        int max = UserB.Length; 
        for (int i = 0; i < max; i++)
        {
            ButtonPosChange(UserB[i], RValue / max * (i+1));
        }
    }


    public static double ConvertRadiansToDegrees(double radians)
    {
        double degrees = (180 / Math.PI) * radians;
        return (degrees);
    }
}
