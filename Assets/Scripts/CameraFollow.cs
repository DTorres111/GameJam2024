using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target; // The target the camera will follow

    void Update()
    {
        // Update the camera's position to follow the target on the x-axis only
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

}
