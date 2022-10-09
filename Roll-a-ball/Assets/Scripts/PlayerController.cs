using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX, movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        int currentSecond = DateTime.Now.Second;
        string half;
        string extraLetter;
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            if (currentSecond <= 30)
            {
                half = " FirstHalf";
            }
            else
            {
                half = " SecondHalf";
            }
            if (currentSecond < 10 || currentSecond < 30 && currentSecond > 19 || currentSecond < 50 && currentSecond > 39)
            {
                extraLetter = " a";
            }
            else
            {
                extraLetter = " b";
            }
            Debug.Log("Collected at "+currentSecond.ToString()+" seconds!" + half + extraLetter);
        }
    }
}
