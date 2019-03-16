using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over_Scene : MonoBehaviour {

    public Text gameOverText;
    public Text scoreBoard;
    public Text highestScoreBoard;
    public Text leaderboard;
    public Text firstPlace;
    public Text secondPlace;
    public Text thirdPlace;
    public RectTransform reset;
    public Image resetImage;
    public Image leaderboardBox;
    public Image leaderBoardBoxFill;
    public RectTransform home;
    public RectTransform logInButton;
    public RectTransform leaderboardButton;

    private float highestScore;

    //This is the aspect of TextPosition/ScreenHeight in a correct looking screen
    private float gameOverTextPos = 0.3255f;
    private float scoreBoardPos = 0.1563f;
    private float highestScoreBoardPos = 0.1042f;
    private float leaderboardPos = 0.03125f;
    private float firstPlacePos = -0.0260f;
    private float secondPlacePos = -0.0573f;
    private float thirdPlacePos = -0.0911f;
    private float leaderboardBoxPos = -0.0599f;
    private float resetPos = -0.2291f;
    private float logInButtonPos = -0.3750f;

    //This is the aspect of ContainerHeight/ScreenHeight in a correct looking screen
    private float gameOverTextHeight = 0.2083f;
    private float scoreBoardHeight = 0.0391f;
    private float highestScoreBoardHeight = 0.0365f;
    private float leaderboardHeight = 0.0339f;
    private float firstPlaceHeight = 0.0261f;
    private float secondPlaceHeight = 0.0261f;
    private float thirdPlaceHeight = 0.0261f;
    private float leaderboardBoxHeight = 0.1302f;
    private float leaderboardBoxFillHeight = 0.125f;
    private float homePosHeight = 0.3910f;
    private float logInButtonHeight = 0.0589f;

    //This is the aspect of ContainerWidth/ScreenWidth in a correct looking screen
    private float gameOverTextWidth = 0.5555f;
    private float scoreBoardWidth = 1f;
    private float highestScoreBoardWidth = 1f;
    private float leaderboardBoxWidth = 0.6944f;
    private float leaderboardBoxFillWidth = 0.6852f;
    private float homePosWidth = -0.3241f;
    private float logInButtonWidth = 0.3646f;

    //This is the aspect of FontSize/ScreenHeight in a correct looking screen
    private float gameOverTextSize = 0.0911f;
    private float scoreBoardSize = 0.0364f;
    private float highestScoreBoardSize = 0.0338f;
    private float leaderboardSize = 0.0338f;
    private float firstPlaceSize = 0.0260f;
    private float secondPlaceSize = 0.0260f;
    private float thirdPlaceSize = 0.0260f;
    private float resetSize = 0.1953f;
    private float resetImageSize = 0.1302f;
    private float homeSize = 0.0781f;

    // Use this for initialization
    void Start() {

        //Sets the correct position for every screen size
        gameOverText.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * gameOverTextPos));
        scoreBoard.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * scoreBoardPos));
        highestScoreBoard.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * highestScoreBoardPos));
        leaderboard.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * leaderboardPos));
        firstPlace.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * firstPlacePos));
        secondPlace.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * secondPlacePos));
        thirdPlace.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * thirdPlacePos));
        leaderboardBox.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * leaderboardBoxPos));
        leaderBoardBoxFill.rectTransform.position = new Vector2(Screen.width/2, (Screen.height/2)+(Screen.height*leaderboardBoxPos));
        reset.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * resetPos));
        home.position = new Vector2((Screen.width / 2) + (Screen.width * homePosWidth), (Screen.height/2)+(Screen.height*homePosHeight));
        logInButton.position = new Vector2(Screen.width/2,(Screen.height/2)+(Screen.height*logInButtonPos));
        leaderboardButton.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * leaderboardBoxPos));

        //Sets the correct container's size for every screen size
        gameOverText.rectTransform.sizeDelta = new Vector2(gameOverTextWidth * Screen.width, gameOverTextHeight * Screen.height);
        scoreBoard.rectTransform.sizeDelta = new Vector2(scoreBoardWidth * Screen.width, scoreBoardHeight * Screen.height);
        highestScoreBoard.rectTransform.sizeDelta = new Vector2(highestScoreBoardWidth * Screen.width, highestScoreBoardHeight * Screen.height);
        leaderboard.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height*leaderboardHeight);
        firstPlace.rectTransform.sizeDelta = new Vector2(Screen.width*leaderboardBoxFillWidth, Screen.height*firstPlaceHeight);
        secondPlace.rectTransform.sizeDelta = new Vector2(Screen.width*leaderboardBoxFillWidth, Screen.height*secondPlaceHeight);
        thirdPlace.rectTransform.sizeDelta = new Vector2(Screen.width*leaderboardBoxFillWidth, Screen.height*thirdPlaceHeight);
        leaderboardBox.rectTransform.sizeDelta = new Vector2(Screen.width*leaderboardBoxWidth, Screen.height*leaderboardBoxHeight);
        leaderBoardBoxFill.rectTransform.sizeDelta = new Vector2(Screen.width*leaderboardBoxFillWidth, Screen.height*leaderboardBoxFillHeight);
        reset.sizeDelta = new Vector2(Screen.height * resetSize, Screen.height * resetSize);
        resetImage.rectTransform.sizeDelta = new Vector2(Screen.height * resetImageSize, Screen.height * resetImageSize);
        home.sizeDelta = new Vector2(Screen.height*homeSize, Screen.height*homeSize);
        logInButton.sizeDelta = new Vector2(Screen.height*logInButtonWidth, Screen.height*logInButtonHeight);
        leaderboardButton.sizeDelta = new Vector2(Screen.width * leaderboardBoxWidth, Screen.height * leaderboardBoxHeight);

        //Sets th fontsize in the correct aspect
        gameOverText.fontSize = Mathf.RoundToInt(Screen.height * gameOverTextSize);
        scoreBoard.fontSize = Mathf.RoundToInt(Screen.height * scoreBoardSize);
        highestScoreBoard.fontSize = Mathf.RoundToInt(Screen.height * highestScoreBoardSize);
        leaderboard.fontSize = Mathf.RoundToInt(Screen.height*leaderboardSize);
        firstPlace.fontSize = Mathf.RoundToInt(Screen.height*firstPlaceSize);
        secondPlace.fontSize = Mathf.RoundToInt(Screen.height*secondPlaceSize);
        thirdPlace.fontSize = Mathf.RoundToInt(Screen.height*thirdPlaceSize);
        

        //Stes the text as the one in the bridge script
        scoreBoard.text = "Score: " + Data_Bridge.Score.ToString();

        //Gets the highest score
        LoadScore();

        //Calls the score into the function and checks if it's the hisghest score
        WriteScore(Data_Bridge.Score);

        //Prints the highest score
        highestScoreBoard.text = "Highest Score: " + highestScore.ToString();

        //Every 5 plays, it shows an ad
        Data_Bridge.TimesPlayed++;
        if (Data_Bridge.TimesPlayed % 5 == 0) {
            AdShower.showAd();
        }
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
        Data_Bridge.HighestScore = highestScore;
    }
}
