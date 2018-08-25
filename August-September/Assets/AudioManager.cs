//this script allows easy add/remove of sounds including modifiable properties 
//like audio clip, loop, spacial blend...


using UnityEngine.Audio; //main audio namespace
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

//awake is the same as start method, except it starts playing before start
	void Awake () {

		if(instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds) //to loop thru the sound
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
		
	}

	void Start()
	{
		Play("Theme");
	}
	
	// Update is called once per frame
	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();
	}
}
 