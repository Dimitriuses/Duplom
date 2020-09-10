using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{
    public ITool Tool;
    BoxCollider Collider;
    SpriteRenderer Sprite;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -8);
        if(Tool.Name.Equals("None"))
        {
            Collider.enabled = false;
            Sprite.sprite = null;
        }
        else
        {
            Collider.enabled = true;
            Sprite.sprite = Tool.UIIcon;
        }
    }

    private void OnMouseDown()
    {
        Tool.onClick();
    }

}
