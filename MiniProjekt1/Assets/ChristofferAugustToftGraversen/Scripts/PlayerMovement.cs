using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    float horizontal;
    public float speed = 8f;
    public float jumpingPwr = 16f;
    bool isFacingRight = true;
    bool isJumping = false;
    public GameObject playerPrefab;
    GameObject enemy;
    GameObject msgBox;
    GameObject respawnMsg;
    public static bool isPaused = false;

    void Start()
    {
        msgBox = GameObject.FindWithTag("MsgBox");
        msgBox.GetComponent<Canvas>().enabled = false;
        msgBox.GetComponentInChildren<Renderer>().enabled = false;
        respawnMsg = GameObject.FindWithTag("Respawn");
        respawnMsg.GetComponent<Canvas>().enabled = false;
        respawnMsg.GetComponentInChildren<Renderer>().enabled = false;
        Time.timeScale = 1;
        isPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            enemy = GameObject.FindWithTag("Enemy");

            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPwr);
                animator.SetBool("JumpUp", true);
                isJumping = true;
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                animator.SetBool("JumpUp", true);
                isJumping = true;
            }
            if (isGrounded())
                isJumping = false;
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetBool("NotJumping", isGrounded());
            if (rb.velocity.y < 0)
                animator.SetBool("JumpUp", false);

            Flip();

        }

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Win!");
            Destroy(enemy);
            msgBox.GetComponent<Canvas>().enabled = true;
            msgBox.GetComponentInChildren<Renderer>().enabled = true;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isJumping)
            {
                Debug.Log("Enemy Died");
                Destroy(enemy);
            }
            else
            {
                Debug.Log("You Died");
                Destroy(this.gameObject);
                respawnMsg.GetComponent<Canvas>().enabled = true;
                respawnMsg.GetComponentInChildren<Renderer>().enabled = true;
            }
        }
    }
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
    
}
