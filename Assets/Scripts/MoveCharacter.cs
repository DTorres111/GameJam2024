using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public bool isConjoined = false;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float rotationSpeed = 600f; // Rotation speed

    private bool isGrounded;
    private bool jumpRequest;
    private Rigidbody2D rb;
    public float gScale;
    public float coeff = 1.5f;
    public float jHeight = 5f;
    public float bpWindow = 0.2f;
    public float bpTime;
    private float pressStr;
	
	private bool isCombinable = false; //Becomes true when a potion is consumed.
	
	public Vector2[] squareVertices = new Vector2[1];
    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = Resources.Load<PhysicsMaterial2D>("NoFriction");

        // Lock the rotation of the Rigidbody2D
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		
		SpriteRenderer square_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		Sprite squareSprite = square_SpriteRenderer.sprite;
		squareVertices = squareSprite.vertices;
        gScale = rb.gravityScale;
    }

    void Update()
    {
        // Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            bpTime = 0;
            jumpRequest = true;
            jumpForce = Mathf.Sqrt(jHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
        }

        //Rotating
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                // Reset rotation to level
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                // Rotate to upside down
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        
    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            //play jump
            audioManager.PlaySFX(audioManager.jump);

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpRequest = false;
        }

        if (rb.velocity.y >= -0.05)
        {
            rb.gravityScale = gScale;
        }
        else
        {
            rb.gravityScale = gScale * coeff;
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

            FixedJoint2D fj = gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            isConjoined = true;
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Shape"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
