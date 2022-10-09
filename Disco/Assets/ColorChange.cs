using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public SpriteRenderer square1;
    public SpriteRenderer square2;
    public SpriteRenderer square3;
    public SpriteRenderer square4;
    public int prevSecond;
    public float red = 0;
    public float green = 0;
    public float blue = 0;
    // Start is called before the first frame update
    void Start()
    {
        square3.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        int curSecond = DateTime.Now.Second;
        if (curSecond % 2 == 0)
        {
            square1.color = Color.red;
        }
        else
        {
            square1.color = Color.white;
        }
        if (prevSecond != curSecond)
        {
            square2.color = UnityEngine.Random.ColorHSV();
            prevSecond = curSecond;
        }
        red = red + Time.deltaTime;
        if (red >= 128)
        {
            green = green + Time.deltaTime;
        }
        if (green >= 128)
        {
            blue = blue + Time.deltaTime;
        }
        if (red == 255f)
        {
            red = 0;
        }
        if (green == 255f)
        {
            green = 0;
        }
        if (blue == 255f)
        {
            blue = 0;
        }
        print(red.ToString());
        square3.color = new Color((int)red, (int)green, (int)blue, 255);
    }
}
