using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using Firebase.Database;

public class LeaderoardSceneController : MonoBehaviour
{
    public Text leaderboardText;
    public RectTransform home;

    public ListView leaderboard;

    private List<string> leaderboardItems;

    private float leaderboardTextPos = 0.2865f;

    private float homePosX = -0.3241f;
    private float homePosY = 0.3906f;

    private float leaderboardTextHeight = 0.0781f;
    private float homeHeight = 0.0781f;
    private float leaderboardHeight = 0.6771f;

    private float leaderboardWidth = 0.8796f;

    private float leaderboardSize = 0.0677f;

    // Start is called before the first frame update
    void Start()
    {
        leaderboard = new ListView();
        leaderboardItems = new List<string>();

        leaderboardText.rectTransform.position = new Vector2(Screen.width / 2, (Screen.height / 2) + (Screen.height * leaderboardTextPos));
        home.position = new Vector2((Screen.width/2)+(Screen.width*homePosX), (Screen.height/2)+(Screen.height*homePosY));
        

        leaderboardText.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height * leaderboardTextHeight);
        home.sizeDelta = new Vector2(Screen.height*homeHeight, Screen.height*homeHeight);
        leaderboard.SetSize(new Vector2(Screen.width * leaderboardWidth, Screen.height * leaderboardHeight));

        leaderboardText.fontSize = Mathf.RoundToInt(Screen.height*leaderboardSize);

        FirebaseDatabase.DefaultInstance.RootReference.OrderByKey().ValueChanged += HandleValueChanged;
    }

    void Update()
    {
        
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        int counter = 0;

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        var players = args.Snapshot.Value as Dictionary<string, object>;
        foreach(var item in players)
        {
            counter++;
            AddPlayer(item.Value, item.Key, counter);
        }
    }

    void AddPlayer(object username, string score, float position)
    {
        leaderboardItems.Add(position + ". " + username + ": " + Mathf.Abs(float.Parse(score)));
    }
}
