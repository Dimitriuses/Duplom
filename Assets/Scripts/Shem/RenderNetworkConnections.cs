using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderNetworkConnections : MonoBehaviour
{
    public List<NRItem> Items;
    public Transform ContentPanel;
    public NRItem ListItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Items = new List<NRItem>();
    }

    public void Render()
    {
        foreach (Transform child in ContentPanel)
            Destroy(child.gameObject);
        foreach (NRItem item in Items)
        {
            NRItem newItem = Instantiate(ListItemPrefab,ContentPanel) as NRItem;
            newItem.Point1 = item.Point1;
            newItem.Point2 = item.Point2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
