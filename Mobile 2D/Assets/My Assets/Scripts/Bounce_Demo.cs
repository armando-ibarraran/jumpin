using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Demo : MonoBehaviour {


    public float jumpForce;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //If the object is in this position, it will jump. This function makes it bounce
        if (rb.position.y < -2f) {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode.Impulse);
        }

	}
}
