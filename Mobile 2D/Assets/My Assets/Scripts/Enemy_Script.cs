using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {

    private Rigidbody rb;

    public float Force;

	// Use this for initialization
	void Start () {

        //Declares rb as the RigidBody of the Game Object attached to this script
        rb = GetComponent<Rigidbody>();

        //Checks position
        if (rb.position.x > 0f)
        {
            //Moves the object in the oposite direction of its position (If it's negative, it will move to the positive part of the axis)
            rb.AddForce(new Vector2(-Force, 0f), ForceMode.VelocityChange);
        }
        else if (rb.position.x < 0f) {
            rb.AddForce(new Vector2(Force, 0f), ForceMode.VelocityChange);
        }
	}
	
	// Update is called once per frame
	void Update () {

        //If the object passes this line, it will be destroyed
        if (rb.position.x > 5)
        {
            Destroy(gameObject);
        }
        if (rb.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}
