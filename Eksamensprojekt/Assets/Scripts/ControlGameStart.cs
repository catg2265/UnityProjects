using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGameStart : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == 19 && !gm.EndScreenActivate)
        {
            gm.GameStart = true;
        }
    }
}
