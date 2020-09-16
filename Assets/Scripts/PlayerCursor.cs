﻿using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{
    public ITool Tool;
    BoxCollider2D Collider;
    SpriteRenderer Sprite;

    bool isOnTheShemObj;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();

        //Collider.
        isOnTheShemObj = false;
        OnChangeTool();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 89.9f);
        //Debug.Log(transform.position);
    }

    public void OnChangeTool()
    {
        if (Tool.Name.Equals("None"))
        {
            Collider.enabled = false;
            Sprite.sprite = null;
        }
        else
        {
            Collider.enabled = true;
            Sprite.sprite = Tool.UIIcon;
            Tool.onCursor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
        if(tmpobj != null)
        {
            tmpobj.LaunchPoint.SetActive(true);
            isOnTheShemObj = true;
        }
        //Debug.Log(tmpobj.GetType());
        //Debug.Log("isTrigered");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
        if (isOnTheShemObj && tmpobj != null)
        {
            tmpobj.LaunchPoint.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
        if (isOnTheShemObj && tmpobj != null)
        {
            tmpobj.LaunchPoint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTheShemObj = false;
        //LaunchPoint.SetActive(false);
    }



    private void OnMouseDown()
    {
        if (isOnTheShemObj)
        {
            Debug.Log("Complete");
        }

        //Tool.onClick();
    }



}
