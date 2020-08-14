using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public interface ITool: IItem
    {
        
        void onClick();
        void onEnterToShemObj(ShemObj obj);
        void onExitToShemObj(ShemObj obj);
        void onClickToShemObj(ShemObj obj);
    }
}
