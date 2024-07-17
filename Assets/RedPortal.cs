using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPortal : MonoBehaviour
{
    private Transform destination=null;

    [SerializeField] private float distance = 0.6f;
    [SerializeField] private float bulletDistanceOffset = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
            destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D thingThatHitPortal)
    {
        Debug.Log("Something touched red portal: " + thingThatHitPortal.tag);
        destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();

        if (thingThatHitPortal.tag == "Soldier")
        {

            if (Vector2.Distance(transform.position, thingThatHitPortal.transform.position) > distance)
            {

                thingThatHitPortal.transform.position = new Vector2(destination.position.x, destination.position.y);
            }

        }else if(thingThatHitPortal.tag == "Bullet")
        {
            Debug.Log("red distance: " + distance);
            Debug.Log("red vect dist calc: " + (Vector2.Distance(transform.position, thingThatHitPortal.transform.position)));

            if (Vector2.Distance(transform.position, thingThatHitPortal.transform.position) + bulletDistanceOffset > (distance))
            {
                thingThatHitPortal.transform.position = new Vector2(destination.position.x, destination.position.y);
                
            }
        }
    }
   
}