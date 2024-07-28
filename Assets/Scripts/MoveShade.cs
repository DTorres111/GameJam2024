using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShade : MonoBehaviour
{

    public GameObject topSquare;
    private Rigidbody2D rb;
    //public bool isCollidingWithObstacle = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            // Mirror the position of the top square
            Vector2 topSquarePosition = topSquare.transform.position;
            transform.position = new Vector2(topSquarePosition.x, -topSquarePosition.y - 1.95f);

            // Mirror the rotation of the top square
            transform.rotation = Quaternion.Euler(0, 0, -topSquare.transform.rotation.eulerAngles.z);
        
       
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
