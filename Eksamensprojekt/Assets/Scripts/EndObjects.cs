using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawnable"))
        {
            if (other.gameObject.GetComponent<DetectColCollectible>().CollectibleType < 2)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().EndScreen();
            }
            Destroy(other.gameObject);
        }
    }
}
