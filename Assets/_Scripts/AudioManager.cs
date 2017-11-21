using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	private AudioSource source;

	public static AudioManager Instance { get; private set; }

	void Awake ()
	{
		Instance = this;	
	}

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayAudio(AudioClip clip)
	{
		source.PlayOneShot(clip);
	}
}
