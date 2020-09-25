using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class MatherCardCell: MonoBehaviour
{
    public SpriteRenderer MatherSprite;
    public Image MImage;
    public Button MButton;
    public RectTransform ParentTransform;
    //public CameraGo Camera;

    public CircleCollider2D Collider2D;

    AssetMotherCard AssetMotherCard;
    bool LockCard;
    private void Start()
    {
        //Collider2D = GetComponent<CircleCollider2D>();
        UpdateWidth();
        LockCard = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!LockCard)
        {
            PlayerCursor cursor = collision.gameObject.GetComponent<PlayerCursor>();
            AssetMotherCard motherCard = new AssetMotherCard();
            if(cursor != null)
            {
                if (cursor.Item.GetType().Equals(motherCard.GetType()))
                {
                    motherCard = cursor.Item as AssetMotherCard;
                }
            }
            if (motherCard.Name != null) 
            {
                MatherSprite.sprite = motherCard.UIIcon;
                //MImage.sprite = motherCard.UIIcon;
                AssetMotherCard = motherCard;
                UpdateWidth();
                //UpdateSpritePosition(cursor.transform.position);
            }
        }
        
        
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    PlayerCursor cursor = collision.gameObject.GetComponent<PlayerCursor>();
    //    UpdateSpritePosition(cursor.transform.position);
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerCursor cursor = collision.gameObject.GetComponent<PlayerCursor>();
        if(cursor != null && AssetMotherCard.Equals(cursor.Item) && !LockCard)
        {
            UpdateSpritePosition(cursor.transform.position);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (AssetMotherCard != null)
        {
            PlayerCursor cursor = collision.gameObject.GetComponent<PlayerCursor>();
            if (cursor != null && AssetMotherCard.Equals(cursor.Item) && !LockCard)
            {
                AssetMotherCard = null;
                MatherSprite.sprite = null;
                //MImage.sprite = null;
            }

        }
    }


    private void UpdateSpritePosition(Vector2 CursorPosition)
    {
        //Vector2 RT = new Vector2(transform.position.x - CursorPosition.x, transform.position.y - CursorPosition.y);
        Vector2 RT = new Vector2(CursorPosition.x - transform.position.x,CursorPosition.y - transform.position.y);
        Vector2 RT2 = new Vector2(RT.x * 5, RT.y * 5);
        MatherSprite.transform.position = new Vector3(RT2.x + transform.position.x, RT2.y + transform.position.y, 0);
        MImage.transform.position = new Vector3(RT2.x + transform.position.x, RT2.y + transform.position.y, 0);
        //Debug.Log(transform.position + " " + CursorPosition + " " + RT2 );
    }

    protected void OnRectTransformDimensionsChange()
    {
        UpdateWidth(); // Update every time if parent changed
    }

    private void UpdateWidth()
    {
        if(AssetMotherCard != null)
        {
            //Debug.Log(_rectTransform.sizeDelta);
            //RectTransform BRT = GetComponent<RectTransform>();
            //float HeightParent = GetComponentInParent<RectTransform>().rect.height;
            float HeightParent =ParentTransform.rect.height;
            float tmpX = HeightParent;
            float tmpY = HeightParent;
            //RectTransform rectmp = MatherSprite.GetComponent<RectTransform>();
            //Debug.Log(HeightParent);
            MatherSprite.size = new Vector2(((tmpX / 100) * AssetMotherCard.Height), ((tmpY / 100) * AssetMotherCard.Width));
            MImage.rectTransform.sizeDelta = new Vector2(((tmpX / 100) * AssetMotherCard.Height), ((tmpY / 100) * AssetMotherCard.Width));
            Collider2D.radius = HeightParent / 2;

            //_nameField.rectTransform.sizeDelta = new Vector2(_nameField.rectTransform.rect.height, (float)(10 / 51.70001) * tmp);
            //_nameField.fontSize = (int)((8 / 51.70001) * tmp);
        }

    }

    public void onClick(PlayerCursor cursor)
    {
        //Debug.Log("Cursor: " + (cursor != null).ToString());
        //Debug.Log("AssetCard: " + (AssetMotherCard != null).ToString());
        if (AssetMotherCard != null) 
        {
            //Debug.Log("Asset =" + AssetMotherCard.Name);
            if (!LockCard)
            {
                //Debug.Log("Lock " + LockCard.ToString());
                LockCard = true;
                cursor.ClearToolItems();
                MImage.enabled = true;
                MButton.enabled = true;
                MatherSprite.enabled = false;
                MImage.sprite = AssetMotherCard.UIIcon;
                UpdateSpritePosition(transform.position);

                //OnCollisionStay2D();
                //MatherSprite.sprite = null;
                cursor.OnCangeItem();
            }
            else
            {
                if (cursor.Item.Name.Equals("None"))
                {
                    //Debug.Log("Asset =" + AssetMotherCard.Name);
                    LockCard = false;
                    cursor.Item = AssetMotherCard;
                    MImage.enabled = false;
                    MButton.enabled = false;
                    MatherSprite.enabled = true;
                    MImage.sprite = null;
                    cursor.OnCangeItem();
                }


                //Debug.Log(cursor.Item.Equals(AssetMotherCard));
            }
        }
        
        
    }


    private void Update()
    {
        
    }
}

