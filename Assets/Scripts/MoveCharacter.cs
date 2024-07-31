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
	
	private bool isCombinable = false; //Becomes true when a potion is consumed.
	
	public Vector2[] squareVertices = new Vector2[1];

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = Resources.Load<PhysicsMaterial2D>("NoFriction");
		
		SpriteRenderer square_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		Sprite squareSprite = square_SpriteRenderer.sprite;
		squareVertices = squareSprite.vertices;
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
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Potion"))
		{
			//For a collision with a Potion.
			isCombinable = true;
		}
	}
	

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
		else if (collision.gameObject.CompareTag("Shape") && isCombinable)
		{
			//Combine shapes.
			//ContactPoint2D contactPoint = collision.GetContact(0);
			
			FixedJoint2D fj = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
			fj.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
		}
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Shape"))
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
