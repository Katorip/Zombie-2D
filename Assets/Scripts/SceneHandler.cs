// Manages scene changes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public StaticScript statics;

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene 1");
    }

    public void NewGame()
    {      
        statics.ResetValues();
        SceneManager.LoadScene("MainScene 1");
    }

    public void LoadNewScene(string sceneName)
    {
        statics.UpdateLevelName(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
