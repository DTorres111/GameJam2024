using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isRed;
    public float distance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        if (isRed == false)
        {
            destination = GameObject.FindGameObjectWithTag("RedPortal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet" || other.tag == "Soldier")
        {

            if (Vector2.Distance(transform.position, other.transform.position) > distance)
            {
                other.transform.position = new Vector2(destination.position.x, destination.position.y);
            }
        }
    }

}