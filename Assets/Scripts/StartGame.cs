using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    void Start()
    { 
    }
    void Update()
    {  
    }
  public void OnStartGameClick()
    {     
        SceneManager.LoadScene("Game");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}