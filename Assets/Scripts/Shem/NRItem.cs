using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRItem : MonoBehaviour
{
    public Vector2 Point1;
    public Vector2 Point2;
    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetPosition(0, new Vector3(Point1.x, Point1.y, 0));
        line.SetPosition(1, new Vector3(Point2.x, Point2.y, 0));
    }

    
}
