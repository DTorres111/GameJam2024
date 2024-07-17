using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float healthPoints = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            

            if (healthPoints >= 2)
            {
                healthPoints -= 2;
                Debug.Log("health: " + healthPoints);
            }

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

}
