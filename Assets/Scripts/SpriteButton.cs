using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    public Sprite Sprite { set { GetComponent<SpriteRenderer>().sprite = value; } get => GetComponent<SpriteRenderer>().sprite; }
    public delegate void OnOperation();
    public OnOperation onMouseDown;
    public bool MouseDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        //onMouseDown();
        MouseDown = true;
        Debug.Log("r1");
    }

    private void OnMouseUp()
    {
        MouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
