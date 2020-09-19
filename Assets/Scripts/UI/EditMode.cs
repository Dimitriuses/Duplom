using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Resources;

public class EditMode : MonoBehaviour
{
    [Header("Options")]
    public bool OnEditMode;
    public Color UseColor;
    public Color EditColor;
    public Camera camera;

    [Header("Buttons")]
    public Button EditTrigerButton;

    [Header("Panels")]
    public GameObject EditPanel;

    bool tempEM;
    //ResourcesStorage Resources;

    void Start()
    {
        //////////////////////////////////buttons////////////////////////////
        Button ETB = EditTrigerButton.GetComponent<Button>();
        ETB.onClick.AddListener(EditModeTriger);
        ///////////////////////////////other////////////////////////////////
        tempEM = OnEditMode;
        if (OnEditMode)
        {
            OpenEditPanel();
        }
        else
        {
            CloseEditPanel();
        }
        EditModeTriger();
        //Resources = new ResourcesStorage();
    }

    void EditModeTriger()
    {
        Button ETB = EditTrigerButton.GetComponent<Button>();

        if (OnEditMode)
        {
            OnEditMode = false;
            ETB.GetComponentInChildren<Text>().text = "E";
            camera.backgroundColor = UseColor;
        }
        else
        {
            OnEditMode = true;
            ETB.GetComponentInChildren<Text>().text = "U";
            camera.backgroundColor = EditColor;
        }
        //Resources.TestFill(20,50);
        //Resources.Show();
        //Resources = new ResourcesStorage();
    }
    Vector2 openPosPanel = new Vector2(0.0f, -21.2f);
    //Vector2 closePosPanel = new Vector2(57.2f, -21.2f);
    void OpenEditPanel()
    {
        //Debug.Log("Open");
        //float timeOfTravel = 5; //time after object reach a target place 
        //float currentTime = 0; // actual floting time 
        //float normalizedValue;
        //RectTransform rectTransform = GameObject.Find("EditPanel").GetComponent<RectTransform>();//getting reference to this component 

        //Debug.Log(rectTransform.rect.x);
        //Vector2 closePosPanel = new Vector2(Math.Abs(rectTransform.rect.x) * 2, openPosPanel.y);

        //while (currentTime <= timeOfTravel)
        //{
        //    currentTime += Time.deltaTime;
        //    normalizedValue = currentTime / timeOfTravel; // we normalize our time 

        //    rectTransform.anchoredPosition = Vector2.Lerp(closePosPanel, openPosPanel, normalizedValue);
        //    // yield return null;
        //}

        //IEnumerator LerpObject()
        //{


        //}
        //GameObject EditPanel = GameObject.Find("EditPanel");
        EditPanel.SetActive(true);

    }

    void CloseEditPanel()
    {
        //Debug.Log("Close");
        //float timeOfTravel = 5; //time after object reach a target place 
        //float currentTime = 0; // actual floting time 
        //float normalizedValue;
        //RectTransform rectTransform = GameObject.Find("EditPanel").GetComponent<RectTransform>(); //getting reference to this component 
        //Vector2 closePosPanel = new Vector2(Math.Abs(rectTransform.rect.x) * 2, openPosPanel.y);


        //while (currentTime <= timeOfTravel)
        //{
        //    currentTime += Time.deltaTime;
        //    normalizedValue = currentTime / timeOfTravel; // we normalize our time 

        //    rectTransform.anchoredPosition = Vector2.Lerp(openPosPanel, closePosPanel, normalizedValue);
        //    //yield return null;
        //}

        //IEnumerator LerpObject()
        //{


        //}

        //GameObject EditPanel = GameObject.Find("EditPanel");
        EditPanel.SetActive(false);
    }

    void Update()
    {
        if (tempEM != OnEditMode)
        {
            tempEM = OnEditMode;
            //Debug.Log(EditMode);
            if (OnEditMode)
            {
                OpenEditPanel();
            }
            else
            {
                CloseEditPanel();
            }
        }
    }
}
