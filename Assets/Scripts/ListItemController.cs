using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ListItemController : MonoBehaviour
{

    public Text Name, Description;
    public void ButtonClick ()
    {
       UnityEngine.Debug.Log("Button click.");
    }

}