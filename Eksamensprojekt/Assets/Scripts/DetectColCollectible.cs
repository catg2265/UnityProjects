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
                gm.spawnRate -= 0.1f;
                Destroy(gameObject);
            }
            else if (CollectibleType == 1)
            {
                gm.player.collectible2Count++;
                gm.spawnRate -= 0.1f;
                Destroy(gameObject);
            }
            else if (CollectibleType == 2)
            {
                gm.EndScreen();
            }
        }
    }

    private void Update()
    {
        transform.position += new Vector3(0, 1, 0) * (speed * Time.deltaTime);
    }

    
}


