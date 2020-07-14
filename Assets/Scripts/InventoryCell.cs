using Assets.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class InventoryCell: MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private Text _nameField;
        [SerializeField] private Image _iconField;

        private Transform _draggingParent;
        private Transform _originalParent;

        public void Init(Transform draggingParent)
        {
            _draggingParent = draggingParent;
            _originalParent = transform.parent;
        }
        public void Render(IItem item)
        {
            _nameField.text = item.Name;
            _iconField.sprite = item.UIIcon;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.parent = _draggingParent;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            int closestIndex = 0;

            for (int i = 0; i < _originalParent.transform.childCount; i++)
            {
                if(Vector3.Distance(transform.position, _originalParent.GetChild(i).position)<
                    Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
                {
                    closestIndex = i;
                }
            }

            transform.parent = _originalParent;
            transform.SetSiblingIndex(closestIndex);
        }

    }
}
