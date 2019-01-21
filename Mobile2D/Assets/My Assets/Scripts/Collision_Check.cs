using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check : MonoBehaviour {

    public GameObject collisioner;
    public GameObject textController;

    void OnTriggerEnter(Collider col)
    {
        //Checks if this GameObject is hitten
        if (col.gameObject.name == collisioner.name + "(Clone)")
        {
            textController.GetComponent<Score>().IncreaseScore();
        }
    }

}
