using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Computer : ShemObj
{
    [Header("UseMode")]
    public UseMode UseMode;

    [Header("Computer")]
    public Sprite[] PCMaterials;
    
    //bool isMCARD, isCPU, isGPU, isRAM, isSATA;
    MotherCard MotherCard;

   

    int networkSocets;
    int electricalSocets;

    //int Aop;
    //int Acl;
    //int Ajp;
    //int Adv;
    private void Start()
    {
        base.Start();
        base._OnMouseEnter = UseMode.COnMouseEnter;
        base._OnMouseDown = UseMode.OnMD;
        base._OnMouseExit = UseMode.OnMExit;
        base._OnMouseUp = UseMode.OnMUP;
        base._OnLockChange = isLockedChange;
        UseMode.OnPover = PowerTrigered;
    }

    public void isLockedChange()
    {
        //UnityEngine.Debug.Log(Locked);
        UseMode.BLocked = Locked;
    }

    public void PowerTrigered()
    {
        if (UseMode.isPowerOn)
        {
            GetComponent<SpriteRenderer>().sprite = PCMaterials[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = PCMaterials[0];
        }


    }

}
