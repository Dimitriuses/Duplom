using Assets.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class IToolLogik : ScriptableObject
{
    public string Name;
    

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
    
