using Assets.Scripts;
using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPanel : MonoBehaviour
{
    [SerializeField] private List<AssetTool> Items;
    [SerializeField] private ToolCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private VerticalLayoutGroup _layoutContainer;
    [SerializeField] private Transform _draggingParent;
    public CameraGo Camera;

    //delegate void Run(string name);

    public void OnEnable()
    {
        Render(Items);
    }
    public void Render(List<AssetTool> items)
    {
        //RectTransform rect = GetComponent<RectTransform>();

        //Debug.Log(_layoutContainer.);
        //_layoutContainer.minWidth

        //Run run = ReturnTextureName;

        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Init(_draggingParent);
            cell.Render(item, new ToolCell.Run(ReturnTextureName));
        });
    }
    protected void OnRectTransformDimensionsChange()
    {
        UpdateColiderSize();
    }
    void UpdateColiderSize()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        Debug.Log(box.size + " " + rect.sizeDelta);
        //box.size = rect.sizeDelta;
    }

    void ReturnTextureName(string name)
    {
        AssetTool Aitem = Items.Find(x => x.Name == name);
        Debug.Log(Aitem.UIIcon.name);
    }
    
    private void OnMouseEnter()
    {
        Camera.StopCam = true;
        Camera.StopZoom = true;
    }
    private void OnMouseExit()
    {
        Camera.StopCam = false;
        Camera.StopZoom = false;
    }
}
