using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DragonSoundManager : MonoBehaviour {

    private DragonType dragonType;
    DragonType.eDragonType thisDragon;
    AudioSource audioSource;
    AudioSource stepSource;
    public AudioClip[] clips;

	// Use this for initialization
	void Start () {
        dragonType = GetComponentInParent<DragonType>();
        thisDragon = dragonType.DragonTypeV;
        audioSource = GetComponent<AudioSource>();
        stepSource = GetComponentInParent<AudioSource>();
	}

    void PlaySFX()
    {
        switch (thisDragon)
        {
            case DragonType.eDragonType.AirDragon:
                audioSource.clip = clips[0];
                audioSource.Play();
                break;
            case DragonType.eDragonType.EarthDragon:
                audioSource.clip = clips[1];
                audioSource.Play();
                break;
            case DragonType.eDragonType.FireDragon:
                audioSource.clip = clips[2];
                audioSource.Play();
                break;
            case DragonType.eDragonType.WaterDragon:
                audioSource.clip = clips[3];
                audioSource.Play();
                break;
        }
    }

    public void PlayStep()
    {
        if(stepSource.isPlaying == false)
        {
            stepSource.Play();
        }
        
    }
}
