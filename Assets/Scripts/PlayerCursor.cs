using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{
    public ITool Tool;
    public IItem Item;
    public Camera Camera;
    BoxCollider2D Collider;
    SpriteRenderer Sprite;
    //Image Image;
    RectTransform Rect;

    CameraGo CameraGo;

    bool isOnTheShemObj;
    Vector3 oldposition;
    ShemObj TMP_obj;

    float IW;
    float IH;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
        //Image = GetComponent<Image>();
        Rect = GetComponent<RectTransform>();
        IW = 0;
        IH = 0;

        //Collider.

        CameraGo = Camera.GetComponent<CameraGo>();
        oldposition = transform.position;
        isOnTheShemObj = false;
        OnChangeTool();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
        Sprite.size = new Vector2((CameraGo.zoom / 100 * IW)/2, (CameraGo.zoom / 100 * IH)/2);
        //Rect.sizeDelta = new Vector2(CameraGo.zoom*2+20, CameraGo.zoom*2+20);
        //Image.rectTransform.sizeDelta = new Vector2(CameraGo.zoom, CameraGo.zoom);
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
            //Image.sprite = null;
            IW = 0;
            IH = 0;
        }
        else
        {
            Collider.enabled = true;
            Sprite.sprite = Tool.UIIcon;
            //Image.sprite = Tool.UIIcon;
            IW = Tool.Width;
            IH = Tool.Height;
            Tool.onCursor();
        }
    }

    public void OnCangeItem()
    {
        if(Item.Name.Equals("None"))
        {
            Collider.enabled = false;
            Sprite.sprite = null;
            //Image.sprite = null;
            IW = 0;
            IH = 0;
        }
        else
        {
            Collider.enabled = true;
            Sprite.sprite = Item.UIIcon;
            //Image.sprite = Item.UIIcon;
            IW = Item.Width;
            IH = Item.Height;
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
