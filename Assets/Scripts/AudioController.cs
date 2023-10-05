using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioClip rocketAudio;
    private AudioSource audioSource;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public void StartRocketSound()
    {
        audioSource.clip = rocketAudio;
        audioSource.Play();
    }

    public void StopRocketSound()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
}
