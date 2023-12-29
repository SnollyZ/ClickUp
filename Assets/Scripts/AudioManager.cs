using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip endSound;

    private AudioSource audioSource;

    private float volume = 0.7f;
    
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip clip){
        audioSource.PlayOneShot(clip, volume);
    }

    public void PlayEndSound(){
        PlayOneShot(endSound);
    }
}
