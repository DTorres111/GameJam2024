using UnityEngine;

public class AutoMirrorObject : MonoBehaviour
{
    public bool mirrorX = true; // Set to true to mirror on the X-axis
    public bool mirrorY = false; // Set to true to mirror on the Y-axis

    void Start()
    {
        Mirror();
    }

    private void Mirror()
    {
        Vector3 newScale = transform.localScale;

        if (mirrorX)
        {
            newScale.x = -newScale.x;
        }

        if (mirrorY)
        {
            newScale.y = -newScale.y;
        }

        transform.localScale = newScale;
    }
}
