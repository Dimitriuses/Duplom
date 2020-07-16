using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using UnityEngine.SceneManagement;
//using System.Diagnostics;

public class CameraGo : MonoBehaviour
{
    [Header("WorkSpace Options")]
    public GameObject workSpace;
    public GameObject workGui;

    [Header("StopFunction")]
    public bool StopCam;
    public bool StopZoom;
    //public bool EditMode;
    //public Button EditTrigerButton;

    [Header("Camera")]
    public Camera Camera;
    public float speed = 10.0f;

    Vector3 camPos;
    Vector3 cursorPos;
    Vector3 StartcamPos;

    [Header("Zoom")]
    public float minZoom = 5.0f;
    public float maxZoom = 50.0f;

    float zoom;
    //bool tempEM;

    void Start()
    {
        //workspace = GameObject.Find("Shem WorkSpace");
        //workgui = GameObject.Find("Cam");
        //camPos = transform.position;
        camPos = workSpace.transform.position;//GetComponent<Vector3>();
        camPos.z = -10;
        cursorPos = new Vector3(-1, -1, -1);
        StartcamPos = cursorPos;
        //GetComponent<Camera>().orthographicSize = minZoom;

        //Vector3 size = workspace.transform.localScale;
        //Vector3 Wpos = workspace.transform.position;
        //RectTransform camSize = workgui.GetComponent<RectTransform>();

        //////////////////////////////////buttons////////////////////////////
        //Button ETB = EditTrigerButton.GetComponent<Button>();
        //ETB.onClick.AddListener(EditModeTriger);
        ///////////////////////////////other////////////////////////////////
        //tempEM = EditMode;

    }

    //void EditModeTriger()
    //{
    //    Button ETB = EditTrigerButton.GetComponent<Button>();
        
    //    if (EditMode)
    //    {
    //        EditMode = false;
    //        ETB.GetComponentInChildren<Text>().text = "E";
    //    }
    //    else
    //    {
    //        EditMode = true;
    //        ETB.GetComponentInChildren<Text>().text = "U";
    //    }
    //}
    //Vector2 openPosPanel = new Vector2(0.0f, -21.2f);
    ////Vector2 closePosPanel = new Vector2(57.2f, -21.2f);
    //
    // void OpenEditPanel()
    // {
    //    //Debug.Log("Open");
    //    float timeOfTravel = 5; //time after object reach a target place 
    //    float currentTime = 0; // actual floting time 
    //    float normalizedValue;
    //    RectTransform rectTransform = GameObject.Find("EditPanel").GetComponent<RectTransform>();//getting reference to this component 
    //    //Debug.Log(rectTransform.rect.x);
    //    Vector2 closePosPanel = new Vector2(Math.Abs(rectTransform.rect.x)*2, openPosPanel.y);

    //        while (currentTime <= timeOfTravel)
    //         {
    //             currentTime += Time.deltaTime;
    //             normalizedValue = currentTime / timeOfTravel; // we normalize our time 

    //             rectTransform.anchoredPosition = Vector2.Lerp(closePosPanel, openPosPanel, normalizedValue);
    //            // yield return null;
    //         }

    //     //IEnumerator LerpObject()
    //     //{

             
    //     //}
    // }

    //void CloseEditPanel()
    //{
    //    //Debug.Log("Close");
    //    float timeOfTravel = 5; //time after object reach a target place 
    //    float currentTime = 0; // actual floting time 
    //    float normalizedValue;
    //    RectTransform rectTransform = GameObject.Find("EditPanel").GetComponent<RectTransform>(); //getting reference to this component 
    //    Vector2 closePosPanel = new Vector2(Math.Abs(rectTransform.rect.x)*2, openPosPanel.y);


    //    while (currentTime <= timeOfTravel)
    //        {
    //            currentTime += Time.deltaTime;
    //            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

    //            rectTransform.anchoredPosition = Vector2.Lerp(openPosPanel, closePosPanel, normalizedValue);
    //            //yield return null;
    //        }
        
    //    //IEnumerator LerpObject()
    //    //{

            
    //    //}
    //}

    void Update()
    {
        Vector3 size = workSpace.transform.localScale;
        Vector3 Wpos = workSpace.transform.position;
        RectTransform camSize = workGui.GetComponent<RectTransform>();
        float CWX = 0;
        float CWY = 0;


        Move(camSize,size);
        Zoom();

                
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        

        CWX = workGui.transform.localScale.x * camSize.rect.width;
        CWY = workGui.transform.localScale.y * camSize.rect.height;

        camPos.x = Mathf.Clamp(camPos.x, Wpos.x - size.x / 2 + CWX / 2, Wpos.x + size.x / 2 - CWX / 2);
        camPos.y = Mathf.Clamp(camPos.y, Wpos.y - size.y / 2 + CWY / 2, Wpos.y + size.y / 2 - CWY / 2);

        transform.position = camPos;
        camPos = transform.position;
        
        Camera.orthographicSize = zoom;
        GameObject.Find("Terr").GetComponent<Text>().text = camPos.x + " " + camPos.y;

        //Debug.Log(size.x / (CWX / zoom) + " " + size.y / (CWY / zoom));
        maxZoom = size.y / (CWY / zoom);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onEsc();
        }

        //Debug.Log(((camPos.y - tmp/2 +(tmp/camSize.rect.height*cursorPos.y)) - (camPos.y - tmp / 2 + (tmp / camSize.rect.height * Input.mousePosition.y))) + " --> " + (camPos.y - tmp / 2 + (tmp / camSize.rect.height * Input.mousePosition.y)));
        //Debug.Log(camSize.rect.width + " " + camSize.rect.height);
        //Debug.Log(GameObject.Find("EditPanel").GetComponent<RectTransform>().anchoredPosition);

        //if (tempEM != EditMode)
        //{
        //    tempEM = EditMode;
        //    //Debug.Log(EditMode);
        //    if (EditMode)
        //    {
        //        OpenEditPanel();
        //    }
        //    else
        //    {
        //        CloseEditPanel();
        //    }
        //}

    }
    //bool MBDown = false;
    Vector3 dragPoint = Vector3.zero;
    void Move(RectTransform camSize,Vector3 size)
    {
        if (!StopCam)
        {
            if (Input.GetKey(KeyCode.W))
            {
                camPos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                camPos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                camPos.x -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                camPos.x += speed * Time.deltaTime;
            }
        }
        

        //Vector3 empty = new Vector3(-1, -1, -1);
        float planeDistance = Mathf.Abs(workSpace.transform.position.z) + Mathf.Abs(Camera.transform.position.z);
        Vector3 screenPoint  = Camera.ScreenToWorldPoint( new Vector3(
                                    Input.mousePosition.x,
                                    Input.mousePosition.y,
                                    planeDistance));

        if (Input.GetMouseButtonDown(0) && !StopCam)
        {
            //cursorPos = Input.mousePosition;
            //StartcamPos = camPos;

            dragPoint = screenPoint;
        }
        if(Input.GetMouseButtonUp(0))
        {
            //cursorPos = empty;
            //StartcamPos = empty;
            //camPos += dragPoint - screenPoint;
            dragPoint = Vector3.zero;
            //Debug.Log(dragPoint + " " + screenPoint);
        }
        if(dragPoint != Vector3.zero)
        {
            camPos += dragPoint - screenPoint;
            //float tmp = maxZoom / size.y * zoom;
            //float mousePosY = camPos.y - tmp / 2 + (tmp / camSize.rect.height * Input.mousePosition.y);
            //float StartPointPosY = camPos.y - tmp / 2 + (tmp / camSize.rect.height * cursorPos.y);
            //float mousePosX = camPos.x - tmp / 2 + (tmp / camSize.rect.width * Input.mousePosition.x);
            //float StartPointPosX = camPos.x - tmp / 2 + (tmp / camSize.rect.width * cursorPos.x);

            //camPos.y = StartcamPos.y + (StartPointPosY - mousePosY) * camSize.rect.height / 173.935126f;
            //camPos.x = StartcamPos.x + (StartPointPosX - mousePosX) * camSize.rect.width / 173.935126f;
            //Debug.Log(StartcamPos + " " + (StartPointPosX - mousePosX) * camSize.rect.width / 173.935126f);
        }
    }

    void Zoom()
    {
        if (!StopZoom)
        {
            if (Input.GetKey(KeyCode.KeypadMinus))
            {
                zoom -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.KeypadPlus))
            {
                zoom += speed * Time.deltaTime;
            }

            if (Input.mouseScrollDelta.y > 0)
            {
                zoom -= speed * Time.deltaTime * 10f;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                zoom += speed * Time.deltaTime * 10f;
            }
        }
 
    }

    void onEsc()
    {
        Debug.Log("InPaused");
        SceneManager.LoadScene("Pause");

    }

    //private void OnMouseDown()
    //{
        
    //}


    //string text;
    //float ZoomAmount = 0;
    //float minFov = 15f;
    //float maxFov = 90f;
    //float sensitivity = 10f;
    //GameObject gameObject;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    gameObject = GameObject.Find("Main Camera");
    //    //gameObject = GameObject.Find("Cube");
    //    text = "";
    //    //FollowCam.POI = GameObject.Find("World");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    pz.z = 0;
    //    //GameObject.Find("Terr").GetComponent<Text>().text = "x:" + pz.x + " y:" + pz.y;
    //    float fov = Camera.main.fieldOfView;
    //    fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
    //    fov = Mathf.Clamp(fov, minFov, maxFov);
    //    Camera.main.fieldOfView = fov;
    //    ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
    //    ZoomAmount = Mathf.Clamp(ZoomAmount, -maxFov, maxFov);
    //    var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), maxFov - Mathf.Abs(ZoomAmount));
    //    gameObject.transform.Translate(0, 0, translate * sensitivity * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
    //    //GameObject.Find("Terr").GetComponent<Text>().text = Camera.main.fieldOfView.ToString();
    //    //Debug.Log(text);

    //}
}
