using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour {
    public void LoadMain()
    {             
        //Resets the game
        SceneManager.LoadScene("Main");
        Data_Bridge.Score = 0f;
    }

}
