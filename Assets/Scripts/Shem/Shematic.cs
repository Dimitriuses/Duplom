using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shematic: MonoBehaviour
{
    public PlayerCursor PlayerCursor;
    public ShemToDoService ToDoService;
    public GameObject WorkSpace;
    public RenderNetworkConnections RenderNetworkConnections;
    public List<ShemObj> Objects;
    List<NetworkConnection> NetworkConnections;

    private void Start()
    {
        //Objects = new List<ShemObj>();
        //NetworkConnections = new List<NetworkConnection>();
        //Debug.Log("new complete");
        
    }

    private void Awake()
    {
        NetworkConnections = new List<NetworkConnection>();
        ToDoService.AddNetworkConnection = AddNetworkConnection;
        ToDoService.UpdateRenderConnections = ChangeConnections;
        
        ShemFill();
        RenderConnection(NetworkConnections[0]);
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
        //Debug.Log("Shem fill start");
        //List<ShemObj> objs = WorkSpace.GetComponentsInChildren<ShemObj>().ToList();
        //Debug.Log("ShemObj to list compete " + objs.Count);
        //foreach (ShemObj item in objs)
        //{
        //    Objects.Add(item);
        //    Debug.Log(item.Address.Adress);
        //}
        //Debug.Log("forech Shem complete");
        foreach (ShemObj item in Objects)
        {
            item.Address = new PhysicalAdress();
            item.OnCangeTransform = ChangeConnections;
        }
        //Debug.Log(Objects[0].Address.Adress + " " + Objects[1].Address.Adress);
        NetworkConnection tmp = new NetworkConnection(Objects[0].Address, Objects[1].Address);
        NetworkConnections.Add(tmp);
    }

    public void ChangeConnections(PhysicalAdress exclusion = null)
    {
        RenderNetworkConnections.Items.Clear();
        foreach (NetworkConnection item in NetworkConnections)
        {
            RenderConnection(item,exclusion);
        }
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

    public void RenderConnection(NetworkConnection connection, PhysicalAdress exclusion = null)
    {
        //Debug.Log("Render begin exclusion = " + exclusion);
        Transform transform1;
        Transform transform2;
        //Debug.Log("connection =" + connection.FirstAdress.Adress + " || " + connection.SecondAdress.Adress);
        //if (exclusion != null && connection.FindAdress(exclusion))
        //{
        //    Debug.Log("exclusion Findet = " + exclusion.Adress);
        //    if (connection.FirstAdress.Equals(exclusion))
        //    {
        //        transform1 = PlayerCursor.transform;
        //        transform2 = Objects.Find(x => x.Address.Equals(connection.SecondAdress)).transform;
        //        Debug.Log("Cursor is first");
        //    }
        //    else
        //    {
        //        transform1 = Objects.Find(x => x.Address.Equals(connection.FirstAdress)).transform;
        //        transform2 = PlayerCursor.transform;
        //        Debug.Log("Cursor is second");
        //    }

        //}
        //else
        //{
        //    Debug.Log("Exclusion don`t find");
        //    transform1 = Objects.Find(x => x.Address.Equals(connection.FirstAdress)).transform;
        //    transform2 = Objects.Find(x => x.Address.Equals(connection.SecondAdress)).transform;
        //}

        transform1 = (connection.FirstAdress.Equals(exclusion)) ? PlayerCursor.transform : Objects.Find(x => x.Address.Equals(connection.FirstAdress)).transform;
        transform2 = (connection.SecondAdress.Equals(exclusion)) ? PlayerCursor.transform : Objects.Find(x => x.Address.Equals(connection.SecondAdress)).transform;



        RenderNetworkConnections.Items.Add(new NRItem
        {
            Point1 = new Vector2(transform1.position.x, transform1.position.y),
            Point2 = new Vector2(transform2.position.x, transform2.position.y)
        });
        RenderNetworkConnections.Render();
    }

    public void AddNetworkConnection(NetworkConnection connection, PhysicalAdress exclusion = null)
    {
        NetworkConnection ToDelete = null;
        foreach (NetworkConnection item in NetworkConnections)
        {
            if(item.FindAdress(connection.FirstAdress) || item.FindAdress(connection.SecondAdress))
            {
                ToDelete = item;
                //Debug.Log("V");
            }
            //Debug.Log(item.FirstAdress.Adress + " & " + item.SecondAdress.Adress);
        }
        if(ToDelete != null)
        {
            NetworkConnections.Remove(ToDelete);
            //Debug.Log("Removed " + ToDelete.FirstAdress.Adress + " X " + ToDelete.SecondAdress.Adress);
        }
        NetworkConnections.Add(connection);
        RenderConnection(connection, exclusion);
    }
}

