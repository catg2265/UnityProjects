using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class checkTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().onTrigger = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().triggerName = GetComponentInChildren<TextMeshPro>().text;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovemement>().canMove = false;
    }
}
