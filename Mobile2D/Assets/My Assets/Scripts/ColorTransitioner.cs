using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTransitioner : MonoBehaviour
{
    public List<Transform> front;
    public Transform background;

    public bool isUI;
    public bool isFrontImage;
    public bool backgroundNeeded;

    public Gradient frontColors;
    public Gradient backgroundColors;

    public float speed;

    public List<Transform> uiImages;

    void Start()
    {
        
    }

    void Update()
    {
        if (Data_Bridge.colorMode)
        {
            if (backgroundNeeded)
            {
                if (isUI)
                {
                    foreach (Transform item in uiImages)
                    {
                        if (item == null)
                        {
                            uiImages.Remove(item);
                        }

                        item.GetComponent<Image>().color = backgroundColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
                    }
                }
                else
                {
                    background.GetComponent<Camera>().backgroundColor = backgroundColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
                }
            }

            foreach (Transform item in front)
            {
                if (item == null)
                {
                    front.Remove(item);
                }
                if (isUI)
                {
                    if (isFrontImage)
                    {
                        item.GetComponent<Image>().color = frontColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
                    }
                    else
                    {
                        item.GetComponent<Text>().color = frontColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
                    }
                    
                }
                else
                {
                    item.GetComponent<Renderer>().material.color = frontColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
                }
            }
        }
    }

    public void addToFront(Transform newItem){
        front.Add(newItem);
    }

    public Color FrontColor()
    {
        return frontColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
    }

    public Color BackColor ()
    {
        return backgroundColors.Evaluate(Mathf.PingPong(Time.time * speed, 1));
    }

}