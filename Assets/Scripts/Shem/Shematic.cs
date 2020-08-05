using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shematic: MonoBehaviour
{
    public RenderNetworkConnections RenderNetworkConnections;
    List<ShemObj> Objects;
    List<NetworkConnection> NetworkConnections;

    private void Start()
    {
        Objects = new List<ShemObj>();
        NetworkConnections = new List<NetworkConnection>();
        ShemFill();
        RenderConnection(NetworkConnections[0]);
    }

    public Shematic(List<ShemObj> objs = null, List<NetworkConnection> connections = null)
    {
        Objects = (objs != null) ? objs : new List<ShemObj>();
        NetworkConnections = (connections != null) ? connections : new List<NetworkConnection>();
        ShemFill();
        RenderConnection(NetworkConnections[0]);
    }

    public void ShemFill()
    {
        List<ShemObj> objs = GetComponents<ShemObj>().ToList();
        foreach (ShemObj item in objs)
        {
            Objects.Add(item);
        }
        NetworkConnections.Add(new NetworkConnection() { FirstAdress = Objects[0].Address, SecondAdress = Objects[1].Address });
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

