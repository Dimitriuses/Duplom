using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName ="Tool")]
    public class AssetTool : ScriptableObject, ITool
    {
        public string Name => _name;
        public Sprite UIIcon => _uiItem;

        public float Height => _height;

        public float Width => _width;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _uiItem;
        [SerializeField] private float _height;
        [SerializeField] private float _width;

        public void onEnterToShemObj(ShemObj obj)
        {
            throw new NotImplementedException();
        }

        public void onExitToShemObj(ShemObj obj)
        {
            throw new NotImplementedException();
        }

        public void onClickToShemObj(ShemObj obj)
        {
            throw new NotImplementedException();
        }
    }
}
