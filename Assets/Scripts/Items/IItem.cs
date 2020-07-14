using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public interface IItem
    {
        string Name { get; }
        Sprite UIIcon { get; }
    }
}
