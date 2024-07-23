using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private bool jumpRequest;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = Resources.Load<PhysicsMaterial2D>("NoFriction");
    }

    void Update()
    {
        // Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = false;
        }
    }

    
    void OnCollisionStay2D(Collision2D collision)
    {

        //Making sure the isGrounded flag is properly set when touching both Ground and Obstacle
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
