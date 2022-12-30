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
            Destroy(other.gameObject);
        }
    }
}
