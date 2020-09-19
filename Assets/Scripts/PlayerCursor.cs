using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{
    public ITool Tool;
    public IItem Item;
    BoxCollider2D Collider;
    SpriteRenderer Sprite;

    bool isOnTheShemObj;
    Vector3 oldposition;
    ShemObj TMP_obj;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();


        //Collider.
        oldposition = transform.position;
        isOnTheShemObj = false;
        OnChangeTool();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
        //transform.position = Input.mousePosition;
        //Debug.Log(transform.position);
        if (!Tool.Name.Equals("None"))
        {
            if (!transform.position.Equals(oldposition))
            {
                Tool.CursorCangePosition();
            }
        }
        oldposition = transform.position;
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

    public void OnCangeItem()
    {
        if(Item.Name.Equals("None"))
        {
            Collider.enabled = false;
            Sprite.sprite = null;
        }
        else
        {
            Collider.enabled = true;
            Sprite.sprite = Item.UIIcon;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
        if(tmpobj != null)
        {
            TMP_obj = tmpobj;
            tmpobj.LaunchPoint.SetActive(true);
            isOnTheShemObj = true;
            Tool.onEnterToShemObj(tmpobj);
        }
        //Debug.Log(tmpobj.GetType());
        //Debug.Log("isTrigered");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
        if (isOnTheShemObj && tmpobj != null)
        {
            //tmpobj.LaunchPoint.SetActive(true);
        }
        //Debug.Log("Stay");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
        if (isOnTheShemObj && tmpobj != null)
        {
            tmpobj.LaunchPoint.SetActive(true);
        }
        //Debug.Log("StayT");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(TMP_obj != null)
        {
            ShemObj tmpobj = collision.gameObject.GetComponent<ShemObj>();
            isOnTheShemObj = false;
            //LaunchPoint.SetActive(false);
            if (tmpobj != null)
            {
                Tool.onExitToShemObj(tmpobj);
            }
            TMP_obj = null;
        }
    }



    private void OnMouseDown()
    {
        if (isOnTheShemObj && TMP_obj != null) 
        {
            Tool.onClickToShemObj(TMP_obj);
            //Debug.Log("Complete " + TMP_obj.transform.position);
        }
        //Tool.onClick();
    }



}
