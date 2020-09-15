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

    public void onCursor()
    {
        //Debug.Log("onCursorNetworkWire");
        CursorAdress = new PhysicalAdress();
        //Debug.Log("Network Tool adress => " + CursorAdress.Adress);
    }
    
    public void onClickToShemObj(ShemObj obj)
    {
        throw new NotImplementedException();
    }

    public void onEnterToShemObj(ShemObj obj)
    {
        throw new NotImplementedException();
    }

    public void onExitToShemObj(ShemObj obj)
    {
        throw new NotImplementedException();
    }
}
   
