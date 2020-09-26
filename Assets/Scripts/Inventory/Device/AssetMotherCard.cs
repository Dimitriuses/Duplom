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

    [Header("Display Item")]
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _height;
    [SerializeField] private float _with;
    [Header("Processor Transform")]
    public Vector2 ProcesorPosition;
    public Vector2 ProcesorSize;
    [Header("RAM Transform")]
    public Vector2 RAMSize;
    public Vector2 RAM1Position;
    public Vector2 RAM2Position;
    [Header("Sata Transform")]
    public Vector2 SataSize;
    public Vector2 Sata1Position;
    public Vector2 Sata2Position;


}
