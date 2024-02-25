using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMain : MonoBehaviour
{
	public AudioSource audioSource;

	public AudioClip[] audioSources;

	private int currentTrackIndex = 0;

	// Use this for initialization
	void Start()
	{

		if(audioSources.Length > 0)

		{
			PlayNextTrack();
		}

		else
		{
			Debug.LogWarning("No BGM tracks assigned. Please assign AudioClip assets to the bgmTracks array in the inspector.");
		}
	}

    private void Update()
    {
		if (!audioSource.isPlaying)
		{
			PlayNextTrack();
		}
	}

    void PlayNextTrack()
	{
		// Increment the track index
		currentTrackIndex = (currentTrackIndex + 1) % audioSources.Length;

		// Set the next BGM track
		audioSource.clip = audioSources[currentTrackIndex];

		// Play the BGM track
		audioSource.Play();
	}
}
