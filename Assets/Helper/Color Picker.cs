using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************
 * Attached to Player
 * Color of each player that spawns
 * 
 * Sebastian Balakier
 * 3/13/2025, Version 1.0
 ******************************************************/

public class ColorPicker : MonoBehaviour
{
    private Color[] colors = new Color[]
    {
        Color.blue,
        Color.red,
        Color.green,
        Color.yellow,
    };

    private int index;

    public Color GetColor()
    {
        Color currentColor = colors[index];
        index++;
        if (index >= colors.Length)
        {
            index = 0;
        }

        return currentColor;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
