using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPCEditor : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject ProcessorPanel;
    public InventoryCell _inventoryCellTemplate;
    public List<AssetMotherCard> motherCards;
    public List<AssetCPU> CPUs;
    public VerticalLayoutGroup _layoutContainer;
    public Transform _draggingParent;

    //public SpriteRenderer SpriteMC;


    public PlayerCursor Cursor;
    //public AssetTool NoneItem;
    public CameraGo Camera;

    

    private void OnEnable()
    {
        Cursor.ClearToolItems();
        RenderAll();
        
        Camera.StopCam = true;
        Camera.StopZoom = true;
        Camera.StopUsable = true;
    }
    private void OnDisable()
    {
        Cursor.ClearToolItems();
        Camera.StopCam = false;
        Camera.StopZoom = false;
        Camera.StopUsable = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RenderAll()
    {
        RenderMotherCards(motherCards);
        RenderProcessors(CPUs);
    }
    public void RenderMotherCards(List<AssetMotherCard> items)
    {
        foreach (Transform child in InventoryPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, InventoryPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnMothInvCell));
        });
    }
    public void RenderProcessors(List<AssetCPU> items)
    {
        foreach (Transform child in ProcessorPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, ProcessorPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnCPUInvCell));
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

    void ClickOnMothInvCell(string name)
    {
        IItem Aitem = motherCards.Find(x => x.Name == name);
        //Debug.Log(Aitem.UIIcon.name);

        if (Cursor.Item.Name.Equals(Aitem.Name))
        {
            //Debug.Log("NoneTool");
            Cursor.ClearToolItems();
        }
        else
        {
            Cursor.Item = Aitem;
        }
        Cursor.OnCangeItem();
    }

    void ClickOnCPUInvCell(string name)
    {
        IItem Aitem = CPUs.Find(x => x.Name == name);
        //Debug.Log(Aitem.UIIcon.name);

        if (Cursor.Item.Name.Equals(Aitem.Name))
        {
            //Debug.Log("NoneTool");
            Cursor.ClearToolItems();
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
