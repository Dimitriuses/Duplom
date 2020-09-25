using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPCEditor : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject ProcessorPanel;
    public GameObject RAMPanel;
    public GameObject SataPanel;
    public GameObject GPUPanel;
    public GameObject CoolingPanel;
    public GameObject NetworkPanel;
    public InventoryCell _inventoryCellTemplate;
    public List<AssetMotherCard> motherCards;
    public List<AssetCPU> CPUs;
    public List<AssetRAM> RAMs;
    public List<AssetSataStorage> SataStorages;
    public List<AssetGPU> GPUs;
    public List<AssetCooling> Coolings;
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
    public void OnDisable()
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
        Render(motherCards);
        Render(CPUs);
        Render(RAMs);
        Render(SataStorages);
        Render(GPUs);
        Render(Coolings);
    }
    public void Render(List<AssetMotherCard> items)
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
    public void Render(List<AssetCPU> items)
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

    public void Render(List<AssetRAM> items)
    {
        foreach (Transform child in RAMPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, RAMPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnRAMInvCell));
        });
    }

    public void Render(List<AssetSataStorage> items)
    {
        foreach (Transform child in SataPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, SataPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnSataInvCell));
        });
    }

    public void Render(List<AssetGPU> items)
    {
        foreach (Transform child in GPUPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, GPUPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnGPUInvCell));
        });
    }

    public void Render(List<AssetCooling> items)
    {
        foreach (Transform child in CoolingPanel.transform)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryCellTemplate, CoolingPanel.transform);
            cell.Init(_draggingParent);
            cell.Render(item, new InventoryCell.Run(ClickOnCoolInvCell));
        });
    }

    protected void OnRectTransformDimensionsChange()
    {
        UpdateColiderSize();
    }
    void UpdateColiderSize()
    {
        //BoxCollider box = GetComponent<BoxCollider>();
        RectTransform rect = GetComponent<RectTransform>();
        //box.size = new Vector3(rect.rect.width, rect.rect.height, 1);
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

    void ClickOnRAMInvCell(string name)
    {
        IItem Aitem = RAMs.Find(x => x.Name == name);
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

    void ClickOnSataInvCell(string name)
    {
        IItem Aitem = SataStorages.Find(x => x.Name == name);
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

    void ClickOnGPUInvCell(string name)
    {
        IItem Aitem = GPUs.Find(x => x.Name == name);
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

    void ClickOnCoolInvCell(string name)
    {
        IItem Aitem = Coolings.Find(x => x.Name == name);
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
