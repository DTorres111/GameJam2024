using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject gunSprite;
    public GameObject portalGunSprite;

    void Start()
    {
        gunSprite.SetActive(true);
        portalGunSprite.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunSprite.SetActive(true);
            portalGunSprite.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunSprite.SetActive(false);
            portalGunSprite.SetActive(true);
        }
    }
}
