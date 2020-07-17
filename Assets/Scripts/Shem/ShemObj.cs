using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShemObj : MonoBehaviour
{

    public GameObject LaunchPoint;
    public Camera camera;
    public Canvas UI;

    Vector3 initialPosition;
    Vector2 mousePosition;
    float detaX, detaY;
    public static bool Locked;

    protected delegate void OnOperation();

    
    protected OnOperation _OnMouseDown;
    protected OnOperation _OnMouseUp;
    protected OnOperation _OnMouseEnter;
    protected OnOperation _OnMouseExit;


    Vector3 dragPoint = Vector3.zero;

    // Start is called before the first frame update
    protected void Start()
    {
        initialPosition = transform.position;
        //Debug.Log("Start SemObj");
    }

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LauncPoint");
        LaunchPoint = launchPointTrans.gameObject;
        LaunchPoint.SetActive(false);

    }

    void OnMouseEnter()
    {
        LaunchPoint.SetActive(true);
        //Debug.Log("Enter");
        _OnMouseEnter();
    }

    void OnMouseExit()
    {
        LaunchPoint.SetActive(false);
        //Debug.Log("Exit");
        //_OnMouseExit();
    }
    
    private void OnMouseDown()
    {
        if (UI.GetComponent<EditMode>().OnEditMode)
        {
            camera.GetComponent<CameraGo>().StopCam = true;
            Locked = false;
        }
        else
        {
            Locked = true;
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
        //_OnMouseDown();
    }
    private void OnMouseDrag()
    {
        if (!Locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x - detaX, mousePosition.y - detaY, initialPosition.z);
        }
    }
    private void OnMouseUp()
    {
        if (UI.GetComponent<EditMode>().OnEditMode)
        {
            camera.GetComponent<CameraGo>().StopCam = false;
        }

        //dragPoint = Vector3.zero;
        //_OnMouseUp();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
