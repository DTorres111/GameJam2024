using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public bool introPlaying;
    public bool backgroundPlaying;
   

    [Header ("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip intro;
    public AudioClip success;
    public AudioClip fail;
    public AudioClip jump;

    private void Start()
    {
        
        musicSource.clip = intro;
        musicSource.Play();
        introPlaying = true;
        
    }

    private void Update()
    {
        loopBackgroundMusic();

    }

    public void loopBackgroundMusic()
    {
        if (!musicSource.isPlaying && introPlaying == true)
        {
            introPlaying = false;

        }
        if (!introPlaying && !backgroundPlaying)
        {
            musicSource.clip = background;
            musicSource.Play();
            backgroundPlaying = true;
        }
        if (!musicSource.isPlaying)
        {
            backgroundPlaying = false;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
