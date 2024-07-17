using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireatePowerUp : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            GameObject soldier = other.gameObject;
            Bullet bulletScript = soldier.GetComponentInChildren<Bullet>();

            bulletScript.fireRate -= 0.1f;

            Debug.Log("IncreaseFireRate");
        }
    }

}
