using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    
    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MoveCharacter character = other.GetComponent<MoveCharacter>();
        if (character != null && character.someFlag)
        {
           
            //play success
            audioManager.PlaySFX(audioManager.success);
        }
    }

   
}
