﻿using Assets.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


//[CreateAssetMenu(menuName ="Tool")]
public abstract class AssetTool : ScriptableObject, ITool
{
    public string Name => _name;
    public Sprite UIIcon => _icon;
    public float Height => _height;
    public float Width => _with;
    public ShemToDoService ToDoService;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _height;
    [SerializeField] private float _with;

    public void onCursor()
    {
        //throw new NotImplementedException();
    }

    public void onClick()
    {
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

    public void onClickToShemObj(ShemObj obj)
    {
        //throw new NotImplementedException();
    }

    public void CursorCangePosition()
    {
        //throw new NotImplementedException();
    }
}
