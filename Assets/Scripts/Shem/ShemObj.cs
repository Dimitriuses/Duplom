﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShemObj : MonoBehaviour
{
    public GameObject LaunchPoint;
    public Camera camera;
    public Canvas UI;

    public PhysicalAdress Address;

    Vector3 initialPosition;
    Vector2 mousePosition;
    float detaX, detaY;
    public bool Locked; //{ get { return Locked; } set { Locked = value; _OnLockChange(); } }
    

    public delegate void OnOperation();

    
    protected OnOperation _OnMouseDown;
    protected OnOperation _OnMouseUp;
    protected OnOperation _OnMouseEnter;
    protected OnOperation _OnMouseExit;
    protected OnOperation _OnLockChange;

    public delegate void Changed(PhysicalAdress exclusion = null);
    public Changed OnCangeTransform;

    CameraGo cameraGo;
    Vector3 dragPoint = Vector3.zero;

    public void InitTransform(Vector3 position)
    {
        transform.position = position;
        Start();
    }
    protected void Start()
    {
        //Address = new PhysicalAdress();
        //Debug.Log(Address.Adress);
        initialPosition = transform.position;
        cameraGo = camera.GetComponent<CameraGo>();
        //Debug.Log("Start SemObj");
    }

    void Awake()
    {
        //Transform launchPointTrans = transform.Find("LauncPoint");
        //LaunchPoint = launchPointTrans.gameObject;
        LaunchPoint.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!cameraGo.StopUsable)
        {
            LaunchPoint.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!cameraGo.StopUsable)
        {
            LaunchPoint.SetActive(false);
        }

    }

    void OnMouseEnter()
    {
        if (!cameraGo.StopUsable)
        {
            LaunchPoint.SetActive(true);
            //Debug.Log("Enter");
            _OnMouseEnter();
        }

    }

    void OnMouseExit()
    {
        if (!cameraGo.StopUsable)
        {
            LaunchPoint.SetActive(false);
            //Debug.Log("Exit");
            _OnMouseExit();
        }

    }
    
    private void OnMouseDown()
    {
        if (!cameraGo.StopUsable)
        {
            if (UI.GetComponent<EditMode>().OnEditMode)
            {
                cameraGo.StopCam = true;
                Locked = false;
                _OnLockChange();
            }
            else
            {
                Locked = true;
                _OnLockChange();
            }
            //Debug.Log("MouseClickToSemObj");

            //float planeDistance = Mathf.Abs(transform.position.z) + Mathf.Abs(camera.transform.position.z);
            //Vector3 screenPoint = camera.ScreenToWorldPoint(new Vector3(
            //                            Input.mousePosition.x,
            //                            Input.mousePosition.y,
            //                            planeDistance));
            //if (dragPoint == Vector3.zero)
            //{
            //    dragPoint = screenPoint;
            //    //Debug.Log("In");
            //}
            //else
            //{
            //    transform.position += dragPoint - screenPoint;
            //}
            //Debug.Log(dragPoint + " - " + Input.GetAxis("Mouse X"));
            if (!Locked)
            {

                detaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
                detaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            }
            _OnMouseDown();
        }
    }
    private void OnMouseDrag()
    {
        if (!Locked && !cameraGo.StopUsable)
        {
            OnCangeTransform();
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x - detaX, mousePosition.y - detaY, initialPosition.z);
        }
    }
    private void OnMouseUp()
    {
        if (!cameraGo.StopUsable)
        {
            if (UI.GetComponent<EditMode>().OnEditMode)
            {
                cameraGo.StopCam = false;
            }

            //dragPoint = Vector3.zero;
            _OnMouseUp();
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
    }
}
