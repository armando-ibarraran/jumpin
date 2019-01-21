using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCreator : MonoBehaviour
{
    public GameObject colorController;
    public GameObject extraLifeCanvas;
    public Transform canvas;

    private ParticleSystem ps;

    private float counter = 0f;

    private bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            //Declares psAlive as the state of ps (wether is alive or nor)
            bool psAlive = ps.IsAlive();

            //Checks if the particles are not alive
            if (!psAlive)
            {

                //Used for instantiating the object just once
                while (counter < 1)
                {
                    //Load the ad(extra life) in the canvas
                    Instantiate(extraLifeCanvas, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity, canvas);
                    counter++;
                }



            }
        }
        
    }

    public void loadParticles(Vector2 position)
    {
        if (colorController != null)
        {
            gameObject.GetComponent<Renderer>().material.color = colorController.GetComponent<ColorTransitioner>().FrontColor();
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        transform.position = position;
        ps.Play();
        ready = true;
    }
}
