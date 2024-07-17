using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCursor : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private GameObject crosshairObject;

    void Start()
    {
        CreateCrosshair();
    }

    void OnDisable()
    {
        Cursor.visible = true;
        Destroy(crosshairObject);
    }

    void Update()
    {
        if (crosshairObject == null)
        {
            CreateCrosshair();
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        crosshairObject.transform.position = worldPosition;

        Cursor.SetCursor(crosshairTexture, hotSpot, cursorMode);
        Cursor.visible = false;
    }

    private void CreateCrosshair()
    {
        crosshairObject = new GameObject("PortalCrosshair");
        SpriteRenderer spriteRenderer = crosshairObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 15;
        spriteRenderer.sprite = Sprite.Create(crosshairTexture, new Rect(0, 0, crosshairTexture.width, crosshairTexture.height), new Vector2(0.5f, 0.5f));
    }
}