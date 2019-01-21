using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour {

    public GameObject spawningObject;

    public Vector2 center;
    public Vector2 range;
    public float sleepTime;

    private bool gameOver;

	void Start () {
        gameOver = false;

        //Calls function SpaenObjec, the first after 2 seconds, then after sleepTime
        InvokeRepeating("SpawnObject", 2f, sleepTime);
    }
	
	
	void Update () {
   
	}

    void SpawnObject()
    {

        if (!gameOver)
        {
            //Makes objects appear only on the left or right wall, not in between
            float xAxis = Random.Range(-range.x / 2, range.x / 2) > 0 ? 2.4f : -2.4f;

            //Creates a random position
            Vector2 pos = center + new Vector2(xAxis, Random.Range(-range.y / 2, range.y / 2));

            //Creates the game object: spawningObject, it's position: pos and it's rotation: Quaternion.identity
            Instantiate(spawningObject, pos, Quaternion.identity);

            //Sets sleepTIme shorter 
            sleepTime = sleepTime * 0.6f;
        }
    }


    //Made to be call in BallScript and stops objects from spawning
    public void GameOver() {
        gameOver = true;
    }
}
