using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaDragonController : MonoBehaviour {

    ParticleSystem fireParticles;
    AudioSource fireBreathPlayer;
    Animator mamaAnimator;

    void Start()
    {
        fireParticles = GetComponentInChildren<ParticleSystem>();
        fireBreathPlayer = GetComponent<AudioSource>();
        mamaAnimator = GetComponent<Animator>();
    }

	void OnEnable()
    {
        EventManager.OnLevelEnd += ActivateMomma;
    }
    void OnDisable()
    {
        EventManager.OnLevelEnd -= ActivateMomma;
    }

    void ActivateMomma()
    {
        mamaAnimator.SetTrigger("BreatheFire");
    }

    public void PlayFireParticles()
    {
        fireBreathPlayer.Play();
        fireParticles.Play();
    }

}
