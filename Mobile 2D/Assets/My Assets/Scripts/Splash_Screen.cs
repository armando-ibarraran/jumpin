using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash_Screen : MonoBehaviour {

    public GameObject player;
    public Text title;
    public Text developer;
    public Text instruction;

    private Rigidbody rb;

    //This is the aspect of TextPosition/ScreenHeight in a correct looking screen
    private float titlePos = 0.3125f;
    private float developerPos = 0.2343f;
    private float instructionPos = -0.3645f;

    //This is the aspect of ContainerHeight/ScreenHeight in a correct looking screen
    private float titleHeight = 0.1041f;
    private float developerHeight = 0.03f;
    private float instructionHeight = 0.0520f;

    //This is the aspect of FontSize/ScreenHeight in a correct looking screen
    private float titleSize = 0.1041f;
    private float developerSize = 0.0260f;
    private float instructionSize = 0.0520f;

    // Use this for initialization
    void Start()
    {
        //Sets rb as the rigidbody attached to the GameObject player
        rb = player.GetComponent<Rigidbody>();

        //Sets the correct position for every screen size
        title.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * titlePos));
        developer.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * developerPos));
        instruction.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * instructionPos));

        //Sets the correct size for every screen size
        title.rectTransform.sizeDelta = new Vector2(Screen.width, titleHeight * Screen.height);
        developer.rectTransform.sizeDelta = new Vector2(Screen.width, developerHeight * Screen.height);
        instruction.rectTransform.sizeDelta = new Vector2(Screen.width, instructionHeight * Screen.height);

        //Sets th fontsize in the correct aspect
        title.fontSize = Mathf.RoundToInt(Screen.height * titleSize);
        developer.fontSize = Mathf.RoundToInt(Screen.height * developerSize);
        instruction.fontSize = Mathf.RoundToInt(Screen.height * instructionSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0f || Input.GetButtonDown("Fire1"))
        {
            //Calls LoadMain
            LoadMain();

            //Sets this position so it can be used from another scene
            Data_Bridge.PlayerPosition = new Vector2(rb.position.x, rb.position.y);
        }
    }

    public void LoadMain()
    {
        //Starts or resets the game
        SceneManager.LoadScene("Main");
    }

}
