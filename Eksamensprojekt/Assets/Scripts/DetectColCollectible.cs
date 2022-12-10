using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColCollectible : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private int CollectibleType = 0;
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

            if (CollectibleType == 0)
            {
                gm.player.collectible1Count++;
            }
            else if (CollectibleType == 1)
            {
                gm.player.collectible2Count++;
            }
        }
    }
}


