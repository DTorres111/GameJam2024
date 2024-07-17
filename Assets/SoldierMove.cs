using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 10f;

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z - transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        targetPosition.z = transform.position.z;
     
        Vector3 direction = targetPosition - (transform.position);
        
        //Debug.Log("direction: " + direction);

        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        
        transform.up = targetPosition - (transform.position);

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        transform.position += Camera.main.transform.TransformDirection(movement);

        // Add this line to stop the object from moving as soon as you stop pressing the WASD keys
        if (movement == Vector3.zero)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

}
