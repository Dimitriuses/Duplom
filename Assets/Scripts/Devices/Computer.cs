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
    public RectTransform[] UserB;
    public Sprite[] PowerBMat;
    public CircleCollider2D UseColiider;
    public CircleCollider2D EditCollider;
    public int RValue;
    public float PValue;
    public float Radius;
    public float OValue;

    [Header("Computer")]
    public Sprite[] PCMaterials;
    
    //bool isMCARD, isCPU, isGPU, isRAM, isSATA;
    MotherCard MotherCard;
    Animator Animator;

    bool isPowerOn;
    bool isPowerOpen;
    bool isButtonLock;

    int networkSocets;
    int electricalSocets;

    //int Aop;
    //int Acl;
    //int Ajp;
    //int Adv;
    private void Start()
    {
        base.Start();
        base._OnMouseEnter = COnMouseEnter;
        base._OnMouseDown = OnMD;
        base._OnMouseExit = OnMExit;
        base._OnMouseUp = OnMUP;
        Animator = GetComponent<Animator>();
        //Aop = Animator.StringToHash("openingUserButtons");
        //Acl = Animator.StringToHash("closingUserButtons");
        //Ajp = Animator.StringToHash("Jamping");
        //Adv = Animator.StringToHash("Diving");
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
            Animator.SetTrigger("Open");
        }
        else
        {
            Power.GetComponent<SpriteRenderer>().sprite = PowerBMat[1];
            GetComponent<SpriteRenderer>().sprite = PCMaterials[1];
            Animator.SetTrigger("Close");
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
            Animator.SetTrigger("Jump");
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
            Animator.SetTrigger("Drive");
        }
    }

    private void OnMUP()
    {

    }

    Vector3 ButtonPosChange(/*RectTransform button,*/ float rotateVaule)
    {
        float ammount = (PValue / 100) * rotateVaule / RValue;
        float BRV = ammount * 360;
        double BRVD = ConvertRadiansToDegrees(BRV);
        //button.anchoredPosition = new Vector3((float)Math.Cos(BRVD)*Radius, (float)Math.Sin(BRVD)*Radius, 0);
        return new Vector3((float)Math.Cos(BRVD) * Radius, (float)Math.Sin(BRVD) * Radius, 0);
        //Debug.Log(BRV +"xDEG="+ ConvertRadiansToDegrees(BRV) + " cos=" + Math.Cos(ConvertRadiansToDegrees(BRV)) + "; sin=" + Math.Sin(ConvertRadiansToDegrees(BRV)));
    }

    Vector3 ButtonPosMove(Vector3 vector3)
    {
        return new Vector3((vector3.x/100)*OValue, (vector3.y/100)*OValue, (vector3.z/100)*OValue);
    }

    private void Update()
    {

        int max = UserB.Length; 
        for (int i = 0; i < max; i++)
        {
            //ButtonPosChange(UserB[i], RValue / max * (i+1));
            UserB[i].anchoredPosition = ButtonPosMove(ButtonPosChange(RValue / max * (i + 1)));
        }
        
    }


    public static double ConvertRadiansToDegrees(double radians)
    {
        //double degrees = (180 / Math.PI) * radians;
        double degrees = Math.PI * radians / 180.0;
        return (degrees);
    }
}
