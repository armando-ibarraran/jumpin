using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {

    private Rigidbody rb;

    private bool gameNotOver;

    public GameObject collisioner;
    public GameObject explosion;
    public GameObject textController;
    public GameObject objectSpawner;


    // Use this for initialization
    void Start() {
        //Declares rb as the RigidBody attached to the gameObject this script is attached to
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        //Sets position form the file Data_Bridge
        rb.position = Data_Bridge.PlayerPosition;

        gameNotOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If game isn't over, it runs the code inside the clause
        if (gameNotOver) {

            //If there is a touch on screen...
            if (Input.touchCount > 0f)
            {
                //Creates variable touch as the first Touch on screen
                Touch touch = Input.GetTouch(0);

                //If it the touch just began..
                if (touch.phase == TouchPhase.Began) {
                    //Makes the ball jump
                    rb.AddForce(new Vector2(0f, 7f), ForceMode.Impulse);
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                rb.AddForce(new Vector2(0f, 7f), ForceMode.Impulse);
            }
        }
        
    }

    //This function runs when the object enters into a rigidbody as trigger
    void OnTriggerEnter(Collider col)
    {
        //Checks if this GameObject is hitten by specific object
        if (col.gameObject.name == collisioner.name + "(Clone)")
        {
            //Calls function GameOver
            GameOver();
        }
    }

    void GameOver() {
        gameNotOver = false;

        //Gets the position of the object attached to this script
        Vector2 objectPosition = new Vector2(rb.position.x, rb.position.y);

        //Destroys the Game Object attached to this script
        Destroy(gameObject);

        //Creates the game object explosion with the last postition of the ball
        Instantiate(explosion, objectPosition, Quaternion.identity);

        //Calls GameOver function in Text so it stops counting
        textController.GetComponent<Score>().GameOver();

        //Calls Gameover function in Text so enemies stop spawning
        objectSpawner.GetComponent<Object_Spawner>().GameOver();


        
    }
   
}
