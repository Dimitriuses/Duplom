using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : ShemObj
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        base._OnLockChange = ROnLockedChange;
        base._OnMouseDown = ROnMouseDown;
        base._OnMouseUp = ROnMouseUp;
        base._OnMouseEnter = ROnMouseEnter;
        base._OnMouseExit = ROnMouseExit;
    }

    private void ROnLockedChange()
    {
        
    }

    private void ROnMouseDown()
    {
        
    }

    private void ROnMouseUp()
    {
        
    }

    private void ROnMouseEnter()
    {
        
    }

    private void ROnMouseExit()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
