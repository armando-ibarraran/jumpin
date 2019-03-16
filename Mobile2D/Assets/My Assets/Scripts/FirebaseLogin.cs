using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseLogin : MonoBehaviour
{

    public GameObject loginButton;
    public Text firstPlace;
    public Text secondPlace;
    public Text thirdPlace;

    List<object> scores = new List<object>();
    List<object> usernames = new List<object>();

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    DatabaseReference database;

    private List<string> permissions = new List<string>();

    void Start()
    {

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jumpin-5b93a.firebaseio.com/");
        database = FirebaseDatabase.DefaultInstance.RootReference;

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        if (!FB.IsInitialized)
        {
            Debug.Log("Not initialized");
            FB.Init(SetInit, OnHideUnity);
        }
        else
        {
            Debug.Log("Initialized");
            FB.ActivateApp();
        }

        permissions.Add("public_profile");

        if (FB.IsLoggedIn)
        {
            loginButton.SetActive(false);
            Firebase.Auth.Credential credential = Firebase.Auth.FacebookAuthProvider.GetCredential(AccessToken.CurrentAccessToken.TokenString);
            auth.SignInWithCredentialAsync(credential).ContinueWith((authTask) => {
                if (authTask.IsCanceled)
                {
                    Debug.Log("Sign-in canceled.");
                }
                else if (authTask.IsFaulted)
                {
                    Debug.Log("Sign-in encountered an error.");
                    Debug.Log(authTask.Exception.ToString());
                }
                else if (authTask.IsCompleted)
                {
                    user = auth.CurrentUser;

                    database.Child((-Data_Bridge.HighestScore).ToString()).SetValueAsync(user.DisplayName);
                }
            });


        }
        else
        {
            loginButton.SetActive(true);
        }

        FirebaseDatabase.DefaultInstance.RootReference.OrderByKey().LimitToFirst(3).ValueChanged += HandleValueChanged;


    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Logged in");
        }
        else
        {
            Debug.Log("Not logged in");
        }
    }

    void OnHideUnity(bool isGameShown)
    {
        if (isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void LogIn()
    {
        FB.LogInWithReadPermissions(permissions, AuthCallback);
    }

    void AuthCallback(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            loginButton.SetActive(false);
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    { 

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        
        var players = args.Snapshot.Value as Dictionary<string, object>;
        usernames.Clear();
        scores.Clear();

        foreach(var item in players)
        {
            usernames.Add(item.Value);
            scores.Add(Mathf.Abs(Mathf.Abs(float.Parse(item.Key))));
        }

       
        firstPlace.text = "1. " + usernames[0] + ": " + scores[0].ToString();
        secondPlace.text = "2. " + usernames[1] + ": " + scores[1].ToString();
        thirdPlace.text = "3. " + usernames[2] + ": " + scores[2].ToString();
    }
}

public class User
{
    public string username;
    public float score;

    public User(string username, float score)
    {
        this.username = username;
        this.score = score;
    }
}