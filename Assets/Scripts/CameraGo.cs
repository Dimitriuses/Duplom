using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine.UI;
//using System.Diagnostics;

public class CameraGo : MonoBehaviour
{

    GameObject workspace;

    [Header("Camera")]
    public float speed = 10.0f;

    Vector3 camPos;

    [Header("Zoom")]
    public float minZoom = 5.0f;
    public float maxZoom = 50.0f;

    float zoom;

    void Start()
    {
        workspace = GameObject.Find("Shem WorkSpace");
        //camPos = transform.position;
        camPos = workspace.transform.position;//GetComponent<Vector3>();
        camPos.z = -10;
    }

    void Update()
    {
        Move();

        transform.position = camPos;
        camPos = transform.position;

        Zoom();

        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        GetComponent<Camera>().orthographicSize = zoom;
        GameObject.Find("Terr").GetComponent<Text>().text = camPos.x + " " + camPos.y + " " + camPos.z;
    }

    void Move()
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
