using UnityEngine;

public class SunFollow : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float xOffset = 15f; // Offset to the right

    private float initialYPosition; // Initial Y position of the sun

    void Start()
    {
        // Store the initial Y position of the sun
        initialYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        // Update the sun's position to follow the player's horizontal position with an offset
        Vector3 newPosition = new Vector3(playerTransform.position.x + xOffset, initialYPosition, transform.position.z);
        transform.position = newPosition;
    }
}