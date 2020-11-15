using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PCIExpressCell : MonoBehaviour
{
    public Image AImage;
    //public Button MButton;
    public RectTransform Rect;

    IDevice PCIExpressDevice;
    bool LockCard;
    private void Start()
    {
        //Collider2D = GetComponent<CircleCollider2D>();
        UpdateWidth();
        LockCard = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        


    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    PlayerCursor cursor = collision.gameObject.GetComponent<PlayerCursor>();
    //    UpdateSpritePosition(cursor.transform.position);
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
        
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
        
    //}


    //private void UpdateSpritePosition(Vector2 CursorPosition)
    //{
    //    //Vector2 RT = new Vector2(transform.position.x - CursorPosition.x, transform.position.y - CursorPosition.y);
    //    Vector2 RT = new Vector2(CursorPosition.x - transform.position.x, CursorPosition.y - transform.position.y);
    //    Vector2 RT2 = new Vector2(RT.x * 5, RT.y * 5);
    //    MatherSprite.transform.position = new Vector3(RT2.x + transform.position.x, RT2.y + transform.position.y, 0);
    //    MImage.transform.position = new Vector3(RT2.x + transform.position.x, RT2.y + transform.position.y, 0);
    //    //Debug.Log(transform.position + " " + CursorPosition + " " + RT2 );
    //}

    protected void OnRectTransformDimensionsChange()
    {
        UpdateWidth(); // Update every time if parent changed
    }

    private void UpdateWidth()
    {
        if (PCIExpressDevice != null)
        {
            float HeightParent = Rect.rect.height;
            float tmpX = HeightParent;
            float tmpY = HeightParent;
            AImage.rectTransform.sizeDelta = new Vector2(((tmpX / 100) * PCIExpressDevice.Height), ((tmpY / 100) * PCIExpressDevice.Width));
        }

    }

    public void onClick(PlayerCursor cursor)
    {

        PCIExpress pciexpress = null;
        IDevice device = null;

        if (cursor.Item.GetType().Equals(pciexpress.GetType()))
        {
            device = cursor.Item as IDevice;
        }

        if (!LockCard && device != null)
        {
            LockCard = true;
            cursor.ClearToolItems();
            PCIExpressDevice = device;
            AImage.sprite = device.UIIcon;
            
        }
        else
        {
            if (cursor.Item.Name.Equals("None") && PCIExpressDevice != null)
            {
                LockCard = false;
                cursor.Item = PCIExpressDevice;
                PCIExpressDevice = null;
                AImage.sprite = null;
            }
        }
        cursor.OnCangeItem();
    }


    private void Update()
    {

    }
}