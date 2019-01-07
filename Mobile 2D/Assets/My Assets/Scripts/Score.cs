using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;

    private bool gameOver;

    private float score;

    //This is the aspect of TextPosition/ScreenHeight in a correct looking screen
    private float scoreTextPos = 0.3645f;

    //This is the aspect of Container'sHeight/ScreenHeight in a correct looking screen
    private float scoreTextHeight = 0.0520f;

    //This is the aspect of Container'sWidth/ScreenWidth in a correct looking screen
    private float scoreTextWidth = 1f;

    //This is the aspect of FontSize/ScreenHeight in a correct looking screen
    private float scoreTextSize = 0.0520f;

    // Use this for initialization
    void Start() {

        //Sets the correct position for every screen size
        scoreText.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * scoreTextPos));

        //Sets the correct container's size for every screen size
        scoreText.rectTransform.sizeDelta = new Vector2(scoreTextWidth * Screen.width, scoreTextHeight * Screen.height);

        //Sets th fontsize in the correct aspect
        scoreText.fontSize = Mathf.RoundToInt(Screen.height * scoreTextSize);

        score = Data_Bridge.Score;
        
        gameOver = false;
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = score.ToString();
	}

    public void IncreaseScore() {
        //If the game isn't over, the score increases
        if (!gameOver) {
            score++;
        }
    }


    //Made to be call in Ball_Script
    public void GameOver()
    {
        //Makes the script stop working
        gameOver = true;

       //Submits score so it can be accesed from another scene
        Data_Bridge.Score = score;
    }

    public void setScore() {
        Data_Bridge.Score = score;
    }
}
