using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName ="ShemToDoService")]
public class ShemToDoService: ScriptableObject
{
    public delegate void DoShem();

    public delegate void Change(PhysicalAdress exclusion = null);
    public Change UpdateRenderConnections;

    public delegate void DoNetworkConnection(NetworkConnection connection, PhysicalAdress exclusion = null);
    public DoNetworkConnection AddNetworkConnection;
    public void AddNewNetworkConection(NetworkConnection connection, PhysicalAdress exclusion = null)
    {
        AddNetworkConnection(connection, exclusion);
    }
    public void UpdateConectionsRender(PhysicalAdress exclusion = null)
    {
        UpdateRenderConnections(exclusion);
    }
}

