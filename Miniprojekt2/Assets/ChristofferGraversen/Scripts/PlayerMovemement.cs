using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5f;
    public Animator animator;
    Vector2 movement;
    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x < 0)
        {
            animator.SetFloat("xOld", -1f);
            animator.SetFloat("yOld", 0);
        }
        else if (movement.x > 0)
        {
            animator.SetFloat("xOld", 1f);
            animator.SetFloat("yOld", 0);
        }
        else if (movement.y < 0)
        {
            animator.SetFloat("yOld", -1f);
            animator.SetFloat("xOld", 0);
        }
        else if (movement.y > 0)
        {
            animator.SetFloat("yOld", 1);
            animator.SetFloat("xOld", 0);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}
