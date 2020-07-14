using Assets.Scripts;
using Assets.Scripts.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _draggingParent;

    public void OnEnable()
    {
        Render(Items);
    }
    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Init(_draggingParent);
            cell.Render(item);
        });
    }
}
