using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.Text.RegularExpressions;
//using System.Diagnostics;

public class CameraGo : MonoBehaviour
{

    GameObject workspace;
    GameObject workgui;

    [Header("Camera")]
    public float speed = 10.0f;

    Vector3 camPos;
    Vector3 cursorPos;
    Vector3 StartcamPos;

    [Header("Zoom")]
    public float minZoom = 5.0f;
    public float maxZoom = 50.0f;

    float zoom;

    void Start()
    {
        workspace = GameObject.Find("Shem WorkSpace");
        workgui = GameObject.Find("Cam");
        //camPos = transform.position;
        camPos = workspace.transform.position;//GetComponent<Vector3>();
        camPos.z = -10;
        cursorPos = new Vector3(-1, -1, -1);
        StartcamPos = cursorPos;
        //GetComponent<Camera>().orthographicSize = minZoom;

        //Vector3 size = workspace.transform.localScale;
        //Vector3 Wpos = workspace.transform.position;
        //RectTransform camSize = workgui.GetComponent<RectTransform>();



    }

    void Update()
    {
        Vector3 size = workspace.transform.localScale;
        Vector3 Wpos = workspace.transform.position;
        RectTransform camSize = workgui.GetComponent<RectTransform>();
        float CWX = 0;
        float CWY = 0;


        Move(camSize,size);
        Zoom();

                
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        

        CWX = workgui.transform.localScale.x * camSize.rect.width;
        CWY = workgui.transform.localScale.y * camSize.rect.height;

        camPos.x = Mathf.Clamp(camPos.x, Wpos.x - size.x / 2 + CWX / 2, Wpos.x + size.x / 2 - CWX / 2);
        camPos.y = Mathf.Clamp(camPos.y, Wpos.y - size.y / 2 + CWY / 2, Wpos.y + size.y / 2 - CWY / 2);

        transform.position = camPos;
        camPos = transform.position;
        
        GetComponent<Camera>().orthographicSize = zoom;
        GameObject.Find("Terr").GetComponent<Text>().text = camPos.x + " " + camPos.y;

        //Debug.Log(size.x / (CWX / zoom) + " " + size.y / (CWY / zoom));
        maxZoom = size.y / (CWY / zoom);



        //Debug.Log(((camPos.y - tmp/2 +(tmp/camSize.rect.height*cursorPos.y)) - (camPos.y - tmp / 2 + (tmp / camSize.rect.height * Input.mousePosition.y))) + " --> " + (camPos.y - tmp / 2 + (tmp / camSize.rect.height * Input.mousePosition.y)));
        Debug.Log(camSize.rect.width + " " + camSize.rect.height);

    }

    void Move(RectTransform camSize,Vector3 size)
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

        Vector3 empty = new Vector3(-1, -1, -1);

        if (Input.GetMouseButtonDown(0))
        {
            cursorPos = Input.mousePosition;
            StartcamPos = camPos;
        }
        if(Input.GetMouseButtonUp(0))
        {
            cursorPos = empty;
            StartcamPos = empty;
        }
        if(cursorPos != empty && StartcamPos != empty)
        {
            float tmp = maxZoom / size.y * zoom;
            float mousePosY = camPos.y - tmp / 2 + (tmp / camSize.rect.height * Input.mousePosition.y);
            float StartPointPosY = camPos.y - tmp / 2 + (tmp / camSize.rect.height * cursorPos.y);
            float mousePosX = camPos.x - tmp / 2 + (tmp / camSize.rect.width * Input.mousePosition.x);
            float StartPointPosX = camPos.x - tmp / 2 + (tmp / camSize.rect.width * cursorPos.x);

            camPos.y = StartcamPos.y + (StartPointPosY - mousePosY) * (size.y / (camSize.rect.height / 23f));
            camPos.x = StartcamPos.x + (StartPointPosX - mousePosX) * (size.x / (camSize.rect.width / 41f));
            //Debug.Log(StartcamPos + " " + (StartPointPosY - mousePosY) * 7);
        }
    }

    void Zoom()
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
