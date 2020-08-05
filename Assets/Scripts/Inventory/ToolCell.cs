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
    public class ToolCell: MonoBehaviour//, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private Text _nameField;
        [SerializeField] private Image _iconField;
        [SerializeField] private Button _buttonField;
        private float _prHeight;
        private float _prWidth;
        private RectTransform _rectTransform;

        public delegate void Run(string name);
        Run run;

        private Transform _draggingParent;
        private Transform _originalParent;

        public void Init(Transform draggingParent)
        {
            _draggingParent = draggingParent;
            _originalParent = transform.parent;
            //RectTransform rt = GetComponent<RectTransform>();
            //Debug.Log(rt.sizeDelta);
            //rt.sizeDelta = new Vector2(rt.rect.width, rt.rect.width);
            //Debug.Log(rt.sizeDelta);

        }
        public void Render(ITool item, Run run)
        {
            _nameField.text = item.Name;
            _iconField.sprite = item.UIIcon;
            _prHeight = item.Height;
            _prWidth = item.Width;
            _buttonField.onClick.AddListener(OnClick);
            this.run = run;
            //RectTransform rt = GetComponent<RectTransform>();
            //Debug.Log(rt.sizeDelta);
            //rt.sizeDelta = new Vector2(46, 46);
            //Debug.Log(rt.sizeDelta);
        }

        protected void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            //ScrollRect scrollRect = GetComponentInParent<ScrollRect>();
            //if (scrollRect != null)
            //    _scrollRectRectTransform = scrollRect.GetComponent<RectTransform>();
        }
        protected void OnEnable()
        {
            UpdateWidth();
        }

        protected void OnRectTransformDimensionsChange()
        {
            UpdateWidth(); // Update every time if parent changed
        }

        private void UpdateWidth()
        {
            //Debug.Log(_rectTransform.sizeDelta);
            float tmp = _rectTransform.rect.size.x;

            _rectTransform.sizeDelta = new Vector2(tmp, tmp);
            _iconField.rectTransform.sizeDelta = new Vector2(((tmp / 100) * _prHeight) - 5, ((tmp / 100) * _prWidth) - 5);
            _nameField.rectTransform.sizeDelta = new Vector2(_nameField.rectTransform.rect.height, (float)(10 / 51.70001) * tmp);
            _nameField.fontSize = (int)((8 / 51.70001) * tmp);
        }

        void Update()
        {
            //Debug.Log(_rectTransform.rect.size.x);
        }

        public void OnClick()
        {
            //Debug.Log("Entered " + _nameField.text);
            run(_nameField.text);
            
        }

        //public void OnBeginDrag(PointerEventData eventData)
        //{
        //    transform.parent = _draggingParent;
        //}

        //public void OnDrag(PointerEventData eventData)
        //{
        //    transform.position = Input.mousePosition;
        //}

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //    int closestIndex = 0;

        //    for (int i = 0; i < _originalParent.transform.childCount; i++)
        //    {
        //        if(Vector3.Distance(transform.position, _originalParent.GetChild(i).position)<
        //            Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
        //        {
        //            closestIndex = i;
        //        }
        //    }

        //    transform.parent = _originalParent;
        //    transform.SetSiblingIndex(closestIndex);
        //}

    }
}
