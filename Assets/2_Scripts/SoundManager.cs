using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip audioclip;
    AudioSource scannedSound;

    public static SoundManager instant;

    void Awake(){
        if(SoundManager.instant == null){
            SoundManager.instant = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scannedSound = GetComponent<AudioSource>();
    }
    
    public void scannerSoundPlay(){ 
        scannedSound.PlayOneShot(audioclip);
    }
}