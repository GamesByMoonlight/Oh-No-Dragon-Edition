using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillSFXPlayer : MonoBehaviour {

    AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    void OnEnable()
    {
        EventManager.OnPlayerDeath += PlayStabbySFX;
    }

    void OnDisable()
    {
        EventManager.OnPlayerDeath -= PlayStabbySFX;
    }

    void PlayStabbySFX()
    {
        foreach (AudioSource audioSource in audioSources)
            audioSource.volume = 0.5f;

        audioSources[3].volume = 1;
        audioSources[3].Play();
    }


}
