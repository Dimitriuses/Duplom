﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shematic: MonoBehaviour
{
    public GameObject WorkSpace;
    public RenderNetworkConnections RenderNetworkConnections;
    List<ShemObj> Objects;
    List<NetworkConnection> NetworkConnections;

    private void Start()
    {
        Objects = new List<ShemObj>();
        NetworkConnections = new List<NetworkConnection>();
        //Debug.Log("new complete");
        
    }

    private void Awake()
    {
        ShemFill();
        Debug.Log("fill complete");
        RenderConnection(NetworkConnections[0]);
        Debug.Log("Render complete");
    }

    //public Shematic(List<ShemObj> objs = null, List<NetworkConnection> connections = null)
    //{
    //    Objects = (objs != null) ? objs : new List<ShemObj>();
    //    NetworkConnections = (connections != null) ? connections : new List<NetworkConnection>();
    //    ShemFill();
    //    RenderConnection(NetworkConnections[0]);
    //}

    public void ShemFill()
    {
        Debug.Log("Shem fill start");
        List<ShemObj> objs = WorkSpace.GetComponentsInChildren<ShemObj>().ToList();
        Debug.Log("ShemObj to list compete " + objs.Count);
        foreach (ShemObj item in objs)
        {
            Objects.Add(item);
            Debug.Log(item.Address.Adress);
        }
        Debug.Log("forech Shem complete");
        NetworkConnections.Add(new NetworkConnection() { FirstAdress = Objects[0].Address, SecondAdress = Objects[1].Address });
        Debug.Log("Connection Shem complete");
    }

    public PhysicalAdress GetNextAddress( PhysicalAdress adress )
    {
        foreach (NetworkConnection item in NetworkConnections)
        {
            if (item.FindAdress(adress))
            {
                return item.GetNextAdress(adress);
            }
        }
        return null;
    }

    public void RenderConnection(NetworkConnection connection)
    {
        Transform transform1 = Objects.Find(x => x.Address.Equals(connection.FirstAdress)).transform;
        Transform transform2 = Objects.Find(x => x.Address.Equals(connection.SecondAdress)).transform;
        RenderNetworkConnections.Items.Add(new NRItem
        {
            Point1 = new Vector2(transform1.position.x, transform1.position.y),
            Point2 = new Vector2(transform2.position.x, transform2.position.y)
        });
        Debug.Log("Render");
        RenderNetworkConnections.Render();
    }
}

