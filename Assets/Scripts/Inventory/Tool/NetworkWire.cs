using Assets.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "NetworkWire")]
public class NetworkWire : AssetTool, ITool
{
    PhysicalAdress CursorAdress;
    PhysicalAdress ShemAdress;
    

    public void onCursor()
    {
        //Debug.Log("onCursorNetworkWire");
        CursorAdress = new PhysicalAdress();
        ShemAdress = null;
        //Debug.Log("Network Tool adress => " + CursorAdress.Adress);
    }
    
    public void onClickToShemObj(ShemObj obj)
    {
        PhysicalAdress TMPAdress = obj.Address;
        NetworkConnection connection;
        if (ShemAdress == null)
        {
            connection = new NetworkConnection(CursorAdress, TMPAdress);
            ShemAdress = TMPAdress;
            ToDoService.AddNewNetworkConection(connection, CursorAdress);
        }
        else
        {
            connection = new NetworkConnection(ShemAdress, TMPAdress);
            ShemAdress = null;
            ToDoService.AddNewNetworkConection(connection);
            //ToDoService.UpdateConectionsRender();
        }

        //throw new NotImplementedException();
    }

    public void onEnterToShemObj(ShemObj obj)
    {
        //throw new NotImplementedException();
    }

    public void onExitToShemObj(ShemObj obj)
    {
        //throw new NotImplementedException();
    }
    public void CursorCangePosition()
    {
        if(ShemAdress != null)
        {
            ToDoService.UpdateConectionsRender(CursorAdress);
        }
        
    }
}
   
