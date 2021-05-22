using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public AudioSource audio_game;
	public AudioClip HomeAudio;
	public AudioClip DeathAudio;
	public AudioClip collectAudio;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	public void Home()
	{
		SceneManager.LoadScene("MainMenu");
	}
	public void playMusic()
	{
		audio_game.loop = true;
		audio_game.clip = HomeAudio;
		audio_game.Play();
	}
	public void playDeath()
	{
		audio_game.PlayOneShot(DeathAudio);
	}
	public void playCollect()
	{
		audio_game.PlayOneShot(collectAudio);
	}
}
