using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posMoveObject : MonoBehaviour
{
    public bool isWhite = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isWhite)
        {
            if (collision.CompareTag("blackPiece"))
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("whitePiece"))
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
