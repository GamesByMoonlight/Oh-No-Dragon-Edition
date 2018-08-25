//this is the source where the audiomanager will find the sound

using UnityEngine.Audio;
using UnityEngine;

//allows list of sound elements to appear in inspector for when we create a custom class
[System.Serializable]
public class Sound
{
	public string name;

	public AudioClip clip;

	[Range(0f,1f)] //creates sliders in our unity
	public float volume;
	[Range(.1f,3)]
	public float pitch;

	public bool loop;

	[HideInInspector] //won't show up in inspector
	public AudioSource source;
}