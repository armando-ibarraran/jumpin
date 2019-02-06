using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeScreen : MonoBehaviour
{
    public Text mode;
    public Text classic;
    public Text color;
    public Image classicBox;
    public Image colorBox;
    public Image classicBoxFill;
    public Image colorBoxFill;
    public RectTransform classicButton;
    public RectTransform colorButton;

    //This is the aspect of ObjectPosition/ScreenHeight in a correct looking screen
    private float modePos = 0.3130f;
    private float classicPos = 0.0521f;
    private float colorPos = -0.2083f;

    //This is the aspect of ContainerHeight/ScreenHeight in a correct looking screen
    private float boxHeight = 0.1042f;
    private float boxFillHeight = 0.0990f;

    //This is the aspect of ContainerWidth/ScreenWidth in a correct looking screen
    private float boxWidth = 0.6019f;
    private float boxFillWidth = 0.5926f;

    //This is the aspect of FontSize/ScreenHeight in a correct looking screen
    private float modeSize = 0.1302f;
    private float textSize = 0.0521f;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the correct position for every screen size
        mode.rectTransform.position = new Vector2(Screen.width/2, (Screen.height/2)+(Screen.height*modePos));
        classicButton.position = new Vector2(Screen.width/2, (Screen.height/2)+(Screen.height*classicPos));
        colorButton.position = new Vector2(Screen.width/2, (Screen.height/2)+(Screen.height*colorPos));

        //Sets the correct size for every screen size
        mode.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height*modeSize);
        classic.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height*boxHeight);
        color.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height*boxHeight);
        classicBox.rectTransform.sizeDelta = new Vector2(Screen.width*boxWidth, Screen.height*boxHeight);
        colorBox.rectTransform.sizeDelta = new Vector2(Screen.width * boxWidth, Screen.height * boxHeight);
        classicBoxFill.rectTransform.sizeDelta = new Vector2(Screen.width*boxFillWidth, Screen.height*boxFillHeight);
        colorBoxFill.rectTransform.sizeDelta = new Vector2(Screen.width * boxFillWidth, Screen.height * boxFillHeight);
        classicButton.sizeDelta = new Vector2(Screen.width * boxWidth, Screen.height * boxHeight);
        colorButton.sizeDelta = new Vector2(Screen.width * boxWidth, Screen.height * boxHeight);

        //Sets th fontsize in the correct aspect
        mode.fontSize = Mathf.RoundToInt(Screen.height*modeSize);
        classic.fontSize = Mathf.RoundToInt(Screen.height*textSize);
        color.fontSize = Mathf.RoundToInt(Screen.height*textSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
