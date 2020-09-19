using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class MatherCardCell: MonoBehaviour
{
    public SpriteRenderer MatherSprite;

    AssetMotherCard AssetMotherCard;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
        if(!motherCard.Equals(new AssetMotherCard()))
        {
            MatherSprite.sprite = motherCard.UIIcon;
            AssetMotherCard = motherCard;
        }
        UpdateWidth();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
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
            RectTransform BRT = GetComponent<RectTransform>();
            float tmpX = BRT.rect.x;
            float tmpY = BRT.rect.y;
            RectTransform rectmp = MatherSprite.GetComponent<RectTransform>();

            rectmp.sizeDelta = new Vector2(((tmpX / 100) * AssetMotherCard.Height) - 5, ((tmpY / 100) * AssetMotherCard.Width) - 5);
            //_nameField.rectTransform.sizeDelta = new Vector2(_nameField.rectTransform.rect.height, (float)(10 / 51.70001) * tmp);
            //_nameField.fontSize = (int)((8 / 51.70001) * tmp);
        }

    }


    private void Update()
    {
        
    }
}

