using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over_Scene : MonoBehaviour {

    public Text gameOverText;
    public Text scoreBoard;
    public Text highestScoreBoard;
    public RectTransform reset;
    public Image resetImage;

    private float highestScore;

    //This is the aspect of TextPosition/ScreenHeight in a correct looking screen
    private float gameOverTextPos = 0.2864f;
    private float scoreBoardPos = 0.0781f;
    private float highestScoreBoardPos = 0.0260f;
    private float resetPos = -0.2083f;

    //This is the aspect of ContainerHeight/ScreenHeight in a correct looking screen
    private float gameOverTextHeight = 0.2083f;
    private float scoreBoardHeight = 0.04f;
    private float highestScoreBoardHeight = 0.04f;

    //This is the aspect of ContainerWidth/ScreenWidth in a correct looking screen
    private float gameOverTextWidth = 0.5555f;
    private float scoreBoardWidth = 1f;
    private float highestScoreBoardWidth = 1f;

    //This is the aspect of FontSize/ScreenHeight in a correct looking screen
    private float gameOverTextSize = 0.1041f;
    private float scoreBoardSize = 0.0390f;
    private float highestScoreBoardSize = 0.0364f;
    private float resetSize = 0.1953f;
    private float resetImageSize = 0.1302f;

    // Use this for initialization
    void Start () {

        //Sets the correct position for every screen size
        gameOverText.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * gameOverTextPos));
        scoreBoard.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * scoreBoardPos));
        highestScoreBoard.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * highestScoreBoardPos));
        reset.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * resetPos));

        //Sets the correct container's size for every screen size
        gameOverText.rectTransform.sizeDelta = new Vector2(gameOverTextWidth * Screen.width, gameOverTextHeight * Screen.height);
        scoreBoard.rectTransform.sizeDelta = new Vector2(scoreBoardWidth * Screen.width, scoreBoardHeight * Screen.height);
        highestScoreBoard.rectTransform.sizeDelta = new Vector2(highestScoreBoardWidth * Screen.width, highestScoreBoardHeight * Screen.height);
        reset.sizeDelta = new Vector2(Screen.height * resetSize, Screen.height * resetSize);
        resetImage.rectTransform.sizeDelta = new Vector2(Screen.height * resetImageSize, Screen.height * resetImageSize);

        //Sets th fontsize in the correct aspect
        gameOverText.fontSize = Mathf.RoundToInt(Screen.height * gameOverTextSize);
        scoreBoard.fontSize = Mathf.RoundToInt(Screen.height * scoreBoardSize);
        highestScoreBoard.fontSize = Mathf.RoundToInt(Screen.height * highestScoreBoardSize);
        

        //Stes the text as the one in the bridge script
        scoreBoard.text = "Score: " + Data_Bridge.Score.ToString();

        //Gets the highest score
        LoadScore();

        //Calls the score into the function and checks if it's the hisghest score
        WriteScore(Data_Bridge.Score);

        //Prints the highest score
        highestScoreBoard.text = "Highest Score: " + highestScore.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void LoadScore()
    {
        //Checks if thre's a highest score
        if (PlayerPrefs.HasKey("HighestScore"))
        {
            //Gets the highest score
            highestScore = PlayerPrefs.GetFloat("HighestScore");
        }
        //If there isn't a highest score, it will be 0
        else
        {
            highestScore = 0f;
        }
    }

    void WriteScore(float hS)
    {
        //If the variable given is higher, highest score will become that value
        if(hS > highestScore)
        {
            //Sets it
            highestScore = hS;
        }
        PlayerPrefs.SetFloat("HighestScore", highestScore);
    }
}
