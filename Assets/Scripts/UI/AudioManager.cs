using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
 
    
    public AudioClip backgroundMusic;
    public AudioClip ButtonCLicked;
    public AudioClip Death;
    public AudioClip Sword;
    private static bool mute;

    private void Awake()
    {
        musicSource.clip = backgroundMusic;
      
        
    }

    private void Start()
    {

        if (mute == false)
        {
            musicSource.Play();
            musicSource.loop = true;
            musicSource.volume = 0.2f;
        }
      
       
        
    }
    
    public bool IsMute()
    {
        return mute;

    }

    public void MuteMusic()
    {
        musicSource.Stop();
        mute  = true;
    }
    public void UnMuteMusic()
    {
        musicSource.Play();
        mute  = false;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
}
