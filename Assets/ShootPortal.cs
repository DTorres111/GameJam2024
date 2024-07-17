using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPortal : MonoBehaviour
{
    public GameObject redPortalPrefab;
    public GameObject bluePortalPrefab;

    public Color redColor = Color.red;
    public Color blueColor = Color.blue;

    private static GameObject redPortal;
    private static GameObject bluePortal;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            createPortal();
        }
    }

    void createPortal()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.z = 0f;
        direction.Normalize();

        Color portalColor = Input.GetMouseButtonDown(0) ? redColor : blueColor;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if (hit.collider != null && hit.collider.gameObject.tag == "Wall")
        {
            GameObject portalPrefab = Input.GetMouseButtonDown(0) ? redPortalPrefab : bluePortalPrefab;
            if (portalPrefab == redPortalPrefab)
            {
                if (redPortal != null)
                {
                    Destroy(redPortal);
                }
                redPortal = Instantiate(portalPrefab, hit.point, Quaternion.identity);
                redPortal.transform.up = hit.normal;
                redPortal.GetComponent<SpriteRenderer>().color = portalColor;
            }
            else if (portalPrefab == bluePortalPrefab)
            {
                if (bluePortal != null)
                {
                    Destroy(bluePortal);
                }
                bluePortal = Instantiate(portalPrefab, hit.point, Quaternion.identity);
                bluePortal.transform.up = hit.normal;
                bluePortal.GetComponent<SpriteRenderer>().color = portalColor;
            }
        }
    }
}