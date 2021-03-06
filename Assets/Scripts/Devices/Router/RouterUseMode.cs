﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouterUseMode : MonoBehaviour
{
    [Header("Buttons")]
    public bool BLocked;
    public UnityEngine.UI.Button[] UserB;
    public Button PowerB;
    public Button RebootB;
    public Sprite[] PowerBMat;
    public float Haight;
    public float StartX;
    public float StartY;
    public float RValue;
    public float PValue;
    public float OValue;

    [Header("Indicators")]
    public SpriteRenderer[] Indicators;
    public Color OnColor;
    public Color OffColor;
    public float IValue;

    RectTransform[] UserBRect;
    SpriteRenderer[] UseBRender;
    RectTransform PowerRect;
    SpriteRenderer PoverRender;
    RectTransform RebootRect;
    SpriteRenderer RebootRenderer;
    Animator Animator;
    public bool isPowerOn;
    bool isPowerOpen;

    public delegate void OnOperation();

    public OnOperation OnPover;

    void Start()
    {
        Animator = GetComponent<Animator>();
        //Animator.SetTrigger("Close");
        UserBRect = new RectTransform[UserB.Length];
        UseBRender = new SpriteRenderer[UserB.Length];
        for (int i = 0; i < UserB.Length; i++)
        {
            UserBRect[i] = UserB[i].GetComponent<RectTransform>();
            UseBRender[i] = UserB[i].GetComponent<SpriteRenderer>();
        }
        PowerRect = PowerB.GetComponent<RectTransform>();
        PoverRender = PowerB.GetComponent<SpriteRenderer>();
        RebootRect = RebootB.GetComponent<RectTransform>();
        RebootRenderer = RebootB.GetComponent<SpriteRenderer>();
        isPowerOn = false;
    }

    public void onRebootTrigered()
    {
        if (!isPowerOn)
        {
            PowerTrigered();
        }
    }

    public void onButtonsTrigered()
    {
        //UnityEngine.Debug.Log("Button Trigered");
        if (!isPowerOn)
        {
            PowerTrigered();
        }
    }

    public void PowerTrigered()
    {

        isPowerOn = !isPowerOn;
        //UnityEngine.Debug.Log("Power" + isPowerOn);
        RevizPowerSprite();
        //OnPover();
    }

    void RevizPowerSprite()
    {
        if (isPowerOn && isPowerOpen)
        {
            PoverRender.sprite = PowerBMat[0];
            Animator.SetTrigger("Open");
            Animator.SetBool("isOn", true);
        }
        else
        {
            PoverRender.sprite = PowerBMat[1];
            Animator.SetTrigger("Close");
            Animator.SetBool("isOn", false);
        }
    }

    public void OnMD()
    {
        if (!isPowerOpen && BLocked)
        {
            //Power.GetComponent<Animator>().SetBool("isOpen", true);
            //Power.GetComponent<Animator>();
            isPowerOpen = true;
            Animator.SetTrigger("Jump");
        }
        else if (isPowerOpen)
        {
            //Power.GetComponent<Animator>().SetBool("isOpen", false);
            isPowerOpen = false;
            Animator.SetTrigger("Drive");
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (IValue > 0 && IValue % 10 < 5)
        {
            Indicators[0].color = OnColor;
            for (int i = 1; i < Indicators.Length; i++)
            {
                SpriteChange(Indicators[i], (25 / Indicators.Length) * i);
            }
        }
        else if (IValue < 0)
        {
            for (int i = 0; i < Indicators.Length; i++)
            {
                Indicators[i].color = OffColor;
            }
        }
        float FinishY = StartY + Haight;
        Vector2 StartV = new Vector2(StartX, FinishY);
        Color color = new Color(255, 255, 255, (255 / 100) * OValue);
        PowerRect.anchoredPosition = ButtonPosMove(OpenCloseButtons(StartV, new Vector2(StartX, FinishY)));
        PoverRender.color = color;
        RebootRect.anchoredPosition = ButtonPosMove(OpenCloseButtons(StartV, new Vector2(StartX + RValue, FinishY)));
        RebootRenderer.color = color;
        for (int i = 0; i < UserBRect.Length; i++)
        {
            UserBRect[i].anchoredPosition = ButtonPosMove(OpenCloseButtons(StartV, new Vector2(StartX - RValue, FinishY + Haight * i)));
            UseBRender[i].color = color;
        }
    }

    Vector2 OpenCloseButtons(Vector2 v1, Vector2 v2)
    {
        //Vector2 v1 = rect.anchoredPosition;
        float d = (float)Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y)) / 100;
        float fi = (float)Math.Atan2(v2.y - v1.y, v2.x - v1.x);
        //rect.anchoredPosition = new Vector2(v1.x + PValue * d * (float)Math.Cos(fi), v1.y + PValue * d * (float)Math.Sin(fi));
        return new Vector2(v1.x +PValue * d * (float)Math.Cos(fi), v1.y + PValue * d * (float)Math.Sin(fi));
    }

    Vector2 ButtonPosMove(Vector2 v2)
    {
        Vector2 v1 = new Vector2(v2.x, StartY);
        float d = (float)Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y)) / 100;
        float fi = (float)Math.Atan2(v2.y - v1.y, v2.x - v1.x);
        return new Vector2(v1.x + OValue * d * (float)Math.Cos(fi), v1.y + OValue * d * (float)Math.Sin(fi));
    }

    void SpriteChange(SpriteRenderer sprite,float probaility = 0)
    {
        probaility = (probaility < 0) ? Math.Abs(probaility) : probaility;
        probaility = (probaility > 100) ? 100 : probaility;
        Randomiser randomiser = new Randomiser();
        float TMP = (float)randomiser.GetRandomNumber(0, 99);
        if (TMP < probaility)
        {
            sprite.color = (sprite.color.Equals(OnColor)) ? OffColor : OnColor;
        }
    }
}
