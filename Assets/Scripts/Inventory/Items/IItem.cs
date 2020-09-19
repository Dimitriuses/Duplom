using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IItem
{
    string Name { get; }
    Sprite UIIcon { get; }

    float Height { get; }
    float Width { get; }
}

