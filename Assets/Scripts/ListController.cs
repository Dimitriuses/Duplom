using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;
public class ListController : MonoBehaviour
{
    public Transform ContentPanel;
    public ListItemController ListItemPrefab;
    List<Saving> Loadinds;
    void Start()
    {
        Loadinds = new List<Saving>()
        {
            new Saving
            {
                Name = "Збереження №1"
            },
            new Saving
            {
                Name = "Збереження №2"
            },
            new Saving
            {
                Name = "Збереження №3"
            },
            new Saving
            {
                Name = "Збереження №4"
            },
            new Saving
            {
                Name = "Збереження №5"
            },
            new Saving
            {
                Name = "Збереження №6"
            },
            new Saving
            {
                Name = "Збереження №7"
            },
            new Saving
            {
                Name = "Збереження №8"
            },
            new Saving
            {
                Name = "Збереження №9"
            },
            new Saving
            {
                Name = "Збереження №10"
            },
            new Saving
            {
                Name = "Збереження №11"
            },
            new Saving
            {
                Name = "Збереження №12"
            },
 };

        // 2. Iterate through the data, 
        //	  instantiate prefab, 
        //	  set the data, 
        //	  add it to panel
        foreach (Saving Item in Loadinds)
        {
            ListItemController newItem = Instantiate(ListItemPrefab, ContentPanel) as ListItemController;
            newItem.Name.text = Item.Name;
        }
    }
}