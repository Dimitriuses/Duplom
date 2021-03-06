﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName ="Item")]
    public class AssetItem : ScriptableObject, IItem
    {
        public string Name => _name;
        public Sprite UIIcon => _uiItem;

        public float Height => _height;

        public float Width => _width;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _uiItem;
        [SerializeField] private float _height;
        [SerializeField] private float _width;
    }
}
