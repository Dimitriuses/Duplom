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
    public PlayerCursor Cursor;
    //public AssetTool NoneTool;

    //delegate void Run(string name);

    public void OnEnable()
    {
        Render(Items);
        //Cursor.ClearToolItems();
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
        BoxCollider box = GetComponent<BoxCollider>();
        RectTransform rect = GetComponent<RectTransform>();
        box.size = new Vector3(rect.rect.width, rect.rect.height, 1);
        //Debug.Log(box.size + " " + rect.rect);
    }

    void ReturnTextureName(string name)
    {
        AssetTool Aitem = Items.Find(x => x.Name == name);
        //Debug.Log(Aitem.UIIcon.name);
        
        if (Cursor.Tool.Name.Equals(Aitem.Name))
        {
            //Debug.Log("NoneTool");
            Cursor.ClearToolItems();
        }
        else
        {
            Cursor.Tool = Aitem;
        }
        Cursor.OnChangeTool();
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
