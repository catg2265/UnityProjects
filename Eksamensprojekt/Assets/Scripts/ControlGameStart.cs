using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGameStart : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == 19)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameStart = true;
        }
    }
}
