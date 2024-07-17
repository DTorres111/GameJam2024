using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5000f;
    public float bulletLifetime = 2f;
    public float bulletBounciness = 0.5f;
    public float fireRate = 0.5f;
    private float lastFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastFireTime > fireRate)
        {
            lastFireTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (transform.up) * 0.75f, Quaternion.identity);
            Renderer renderer = bullet.GetComponent<Renderer>();
            renderer.enabled = true;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set the z-coordinate to a constant value
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 direction = targetPosition - bullet.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * bulletSpeed * Time.deltaTime;

            PhysicsMaterial2D material = new PhysicsMaterial2D();
            material.bounciness = bulletBounciness;
            material.friction = 0f;
            Collider2D collider = bullet.GetComponent<Collider2D>();
            collider.sharedMaterial = material;

            Destroy(bullet, bulletLifetime);
        }
    }
}