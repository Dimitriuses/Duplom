using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Resources;
using UnityEngine.UI;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System;
public class UIResources : MonoBehaviour
{
    public Text Money;
    public Text Experience;
    public Text Electrosity;
    ResourcesStorage Resouces;
    public Text TextPrefab;
    public Transform MoneyScrollWiew;
    public Transform ExperienceScrollWiew;
    public Transform ElectricityScrollWiew;
    public Transform NetworkScrollWiew;
    public Color ColorProfit;
    public Color ColorWaste;
    void Start()
    {
        Resouces = new ResourcesStorage(111, 222, 333, 444,1);
        fillRecourcesTest();
        UpdateStatusPanel();
    }
    void UpdateUpPanel()
    {
        List<ResourcesItem> resources = Resouces.GetDefaultResources();
        foreach (ResourcesItem item in resources)
        {
            if (item.Name.Equals(Resouces.NameDefaulMoney))
            {
                Money.text = item.Count.ToString();
            }
            if (item.Name.Equals(Resouces.NameDefaultExperience))
            {
                Experience.text = item.Count.ToString();
            }
            if (item.Name.Equals(Resouces.NameDefaultElectricity))
            {
                Electrosity.text = item.Count.ToString();
            }
        }
    }
    void fillRecourcesTest()
    {
        Resouces.TestFill(10, 100);
        Resouces.Show();
    }
    public void UpdateStatusPanel()
    {
        List<ResourcesItem> resourcesMoney = Resouces.SortByRID(RID.Money);
        List<ResourcesItem> resourcesNetwork = Resouces.SortByRID(RID.Network);
        List<ResourcesItem> resourcesElectricity = Resouces.SortByRID(RID.Electricity);
        foreach (ResourcesItem item in resourcesMoney)
        {
            if (item.Type != RIType.Acumulation)
            {
                Text tmpMoney = Instantiate(TextPrefab, MoneyScrollWiew) as Text;
                tmpMoney.color = (item.Type == RIType.Profit) ? ColorProfit : ColorWaste;
                tmpMoney.text = item.Count.ToString();
            }
            //MoneyScrollWiew.transform.SetAsFirstSibling(Text);
        }
        foreach (ResourcesItem item in resourcesElectricity)
        {
            if (item.Type != RIType.Acumulation)
            {
                Text tmpElectricity = Instantiate(TextPrefab, ElectricityScrollWiew) as Text;
                tmpElectricity.color = (item.Type == RIType.Profit) ? ColorProfit : ColorWaste;
                tmpElectricity.text = item.Count.ToString();
            }
        }
        foreach (ResourcesItem item in resourcesNetwork)
        {
            if (item.Type != RIType.Acumulation)
            {
                Text tmpNetwork = Instantiate(TextPrefab, NetworkScrollWiew) as Text;
                tmpNetwork.color = (item.Type == RIType.Profit) ? ColorProfit : ColorWaste;
                tmpNetwork.text = item.Count.ToString();
            }
        }
        //Resouces.Show();
    }
    public CameraGo Camera;
    public void OnStatusPanelEnable()
    {
        Camera.StopCam = true;
        Camera.StopZoom = true;
    }
    public void OnStatusPanelDisable()
    {
        Camera.StopCam = false;
        Camera.StopZoom = false;
    }
    void Update()
    {
        UpdateUpPanel();
    }
}