using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DetectColCollectible : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private int CollectibleType = 0;
    private float speed = 100f;
    public bool canMove = true;
    
    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CollectibleType == 0)
            {
                gm.player.collectible1Count++;
                canMove = false;
                foreach (var o in GameObject.FindGameObjectsWithTag("Spawnable")) Destroy(o);
                gm.InstantiateRound();
            }
            else if (CollectibleType == 1)
            {
                gm.player.collectible2Count++;
                canMove = false;
                foreach (var o in GameObject.FindGameObjectsWithTag("Spawnable")) Destroy(o);
                gm.InstantiateRound();
            }
            else if (CollectibleType == 2)
            {
                // end game
            }
        }

        // if (other.gameObject.CompareTag("Spawnable"))
        // {
        //     other.gameObject.transform.Rotate(new Vector3(0,60,0));
        // }
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position += new Vector3(0, 1, 0) * (speed * Time.deltaTime);
        }
       
    }
}


