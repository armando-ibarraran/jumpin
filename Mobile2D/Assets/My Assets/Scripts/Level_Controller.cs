using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour {
    public void LoadMain()
    {
        //Resets the game
        Data_Bridge.colorMode = false;
        SceneManager.LoadScene("Main");
    }

    public void LoadModeSelector()
    {
        Data_Bridge.colorMode = true;
        SceneManager.LoadScene("ModeSelector");
    }

    public void LoadColor()
    {
        Data_Bridge.colorMode = true;
        SceneManager.LoadScene("ColorMode");
    }

    public void LoadSplashScreen()
    {
        Data_Bridge.Score = 0f;
        Data_Bridge.colorMode = false;
        SceneManager.LoadScene("Splash_Screen");
    }

    public void newGame()
    {
        Data_Bridge.Score = 0f;
        if (Data_Bridge.colorMode)
        {
            LoadColor();
        }
        else
        {
            LoadMain();
        }
    }
}
