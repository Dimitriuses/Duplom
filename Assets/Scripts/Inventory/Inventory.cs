using Assets.Scripts;
using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private VerticalLayoutGroup _layoutContainer;
    [SerializeField] private Transform _draggingParent;
    public CameraGo Camera;

    //delegate void Run(string name);

    public void OnEnable()
    {
        Render(Items);
    }
    public void Render(List<AssetItem> items)
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
            cell.Render(item, new InventoryCell.Run(ReturnTextureName));
        });
    }

    void ReturnTextureName(string name)
    {
        AssetItem Aitem = Items.Find(x => x.Name == name);
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
