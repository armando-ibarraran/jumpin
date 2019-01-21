using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLifeColor : MonoBehaviour
{

    private GameObject colorTransitioner;

    // Start is called before the first frame update
    void Start()
    {
        colorTransitioner = GameObject.Find("Actors/UIColorController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Data_Bridge.colorMode)
        {
            GetComponent<Image>().color = colorTransitioner.GetComponent<ColorTransitioner>().BackColor();
        }
    }
}
