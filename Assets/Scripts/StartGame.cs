using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
  public void OnStartGameClick()
    {     
        SceneManager.LoadScene("Game");
    }
    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }
}