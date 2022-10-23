// Manages main menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // UI elements
    public GameObject menu;
    public StaticScript statics;
    public Text menuInfo;

    public void Start()
    {
        if (statics.GetLevels() == 1)
        {
            ShowMenu();
            menuInfo.text = "Welcome!";
        }

        else
        {
            HideMenu();
        }
    }

    public void ShowMenu()
    {
        if (statics.GetLevels() == 3)
        {
            menuInfo.text = "Total score: " + statics.GetScores();
        }
        
        menu.SetActive(true);
    }

    public void HideMenu()
    {
        menu.SetActive(false);      
    }
}
