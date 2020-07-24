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
    public ComputerUseMode UseMode;

    [Header("EditMode")]


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
        base._OnMouseEnter = PCOnMouseEnter;
        base._OnMouseDown = PCOnMouseDown;
        base._OnMouseExit = PCOnMouseExit;
        base._OnMouseUp = PCOnMouseUP;
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
    private void PCOnMouseDown()
    {
        if (Locked)
        {
            UseMode.OnMD();
        }
    }
    private void PCOnMouseUP()
    {
        if (Locked)
        {
            UseMode.OnMUP();
        }
    }

    private void PCOnMouseEnter()
    {
        if (Locked)
        {
            UseMode.COnMouseEnter();
        }
    }

    private void PCOnMouseExit()
    {
        if (Locked)
        {
            UseMode.OnMExit();
        }
    }

}
