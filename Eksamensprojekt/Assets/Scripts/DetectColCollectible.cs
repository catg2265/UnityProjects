using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColCollectible : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!gm.FirstCol)
            {
                gm.FirstCol = true;
            }
            
        }
    }
}


