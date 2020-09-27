using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Asset Mother Card")]
public class AssetMotherCard : MotherCard, IDevice
{
    public string Name => _name;
    public Sprite UIIcon => _icon;
    public float Height => _height;
    public float Width => _with;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _height;
    [SerializeField] private float _with;

    
}
