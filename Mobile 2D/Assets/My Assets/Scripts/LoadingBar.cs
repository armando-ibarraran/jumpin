using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{

    public GameObject extraLifeCanvas;
    public Text extraLife;
    public Image radialProgressBar;
    public Image loadingBar;
    public Image center;
    public RectTransform button;
    public Image adIcon;

    private GameObject scoreBoard;
    private GameObject textController;

    //This is the aspect of Object'sPosition/ScreenHeight in a correct looking screen
    private float extraLifePos = 0.2083f;
    private float radialProgressBarPos = -0.1041f;

    //This is the aspect of ContainerHeight/ScreenHeight in a correct looking screen
    private float extraLifeHeight = 0.0781f;
    private float radialProgressBarHeight = 0.3125f;
    private float loadingBarHeight = 0.3125f;
    private float centerHeight = 0.2864f;
    private float buttonHeight = 0.2604f;
    private float adIconHeight = 0.1119f;

    //This is the aspect of ContainerWidth/ScreenWidth in a correct looking screen
    private float extraLifeWidth = 1f;
    private float adIconWidth = 0.2407f;

    //This is the aspect of FontSize/ScreenHeight in a correct looking screen
    private float extraLifeSize = 0.0781f;


    //Duration of the timer
    private float loadingDuration = 3f;

    //Used for displaying the loading bar
    private float timer;

    //Checks if the timer can run
    private bool canCount = true;



    // Start is called before the first frame update
    void Start()
    {
        //Sets the time left as the duration
        timer = loadingDuration;

        //Links the game object and saves the score
        textController = GameObject.Find("Actors/Text_Controller");
        textController.GetComponent<Score>().setScore();

        //Links the game object and destroys the text
        scoreBoard = GameObject.Find("Canvas/ScoreBoard");
        Destroy(scoreBoard);

        //Sets the correct position for every screen size
        extraLife.rectTransform.position = new Vector2(Screen.width/2, (Screen.height/2)+(extraLifePos * Screen.height));
        radialProgressBar.rectTransform.position = new Vector2(Screen.width/2, (Screen.height / 2) + (radialProgressBarPos * Screen.height));

        //Sets the correct container's size for every screen size
        extraLife.rectTransform.sizeDelta = new Vector2(extraLifeWidth * Screen.width, extraLifeHeight * Screen.height);
        radialProgressBar.rectTransform.sizeDelta = new Vector2(radialProgressBarHeight * Screen.height, radialProgressBarHeight * Screen.height);
        loadingBar.rectTransform.sizeDelta = new Vector2(loadingBarHeight * Screen.height, loadingBarHeight * Screen.height);
        center.rectTransform.sizeDelta = new Vector2(centerHeight * Screen.height, centerHeight * Screen.height);
        button.sizeDelta = new Vector2(buttonHeight * Screen.height, buttonHeight * Screen.height);
        adIcon.rectTransform.sizeDelta = new Vector2(adIconWidth * Screen.width, adIconHeight * Screen.height);

        //Sets th fontsize in the correct aspect
        extraLife.fontSize = Mathf.RoundToInt(extraLifeSize * Screen.height);

        
    }

    // Update is called once per frame
    void Update()
    {
        //If the timer is over zero, it counts down
        if (timer > 0.0f && canCount) {
            //Counts down
            timer -= Time.deltaTime;

            //If the timer is under or equal to zero
        } else if (timer <= 0.0f) {
            //It can no longer count
            canCount = false;

            //Sets the timer to 0.0f, just in case it was lower
            timer = 0.0f;

            //Loads the game over scene
            SceneManager.LoadScene("GameOverScreen");
        }

        //The time left divided by the duration is the progress of the bar
        loadingBar.fillAmount = timer / loadingDuration;
    }
}
