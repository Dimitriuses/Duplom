using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPCEditor : MonoBehaviour
{
    public GameObject InventoryPanel;
    public InventoryCell _inventoryCellTemplate;
    public List<AssetMotherCard> Devices;
    public VerticalLayoutGroup _layoutContainer;
    public Transform _draggingParent;

    //public SpriteRenderer SpriteMC;


    public PlayerCursor Cursor;
    public AssetTool NoneItem;
    public CameraGo Camera;



    private void OnEnable()
    {
        Cursor.Item = NoneItem;
        Render(Devices);
        Camera.StopCam = true;
        Camera.StopZoom = true;
    }
    private void OnDisable()
    {
        Camera.StopCam = false;
        Camera.StopZoom = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Render(List<AssetMotherCard> items)
    {
        foreach (Transform child in InventoryPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, InventoryPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnInvCell));
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
        //SpriteMC.size = new Vector2()
        //Debug.Log(box.size + " " + rect.rect);
    }

    void ClickOnInvCell(string name)
    {
        IItem Aitem = Devices.Find(x => x.Name == name);
        //Debug.Log(Aitem.UIIcon.name);

        if (Cursor.Item.Name.Equals(Aitem.Name))
        {
            //Debug.Log("NoneTool");
            Cursor.Item = NoneItem;
        }
        else
        {
            Cursor.Item = Aitem;
        }
        Cursor.OnCangeItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
