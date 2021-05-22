using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject bestScoreDisplay;
	public GameObject AudioPanel;
	public int bestScore;
	public Slider volumesider;

	private void Start()
	{
		bestScore = PlayerPrefs.GetInt("LevelScore");
		bestScoreDisplay.GetComponent<Text>().text = "BEST SCORE: " + bestScore;
		GameManager.instance.playMusic();
		if (PlayerPrefs.HasKey("MusicVolume"))
		{
			PlayerPrefs.SetFloat("MusicVolume", 1);
			Load();
		}
		else
		{
			Load();
		}
	}

	public void ResetBest()
	{
		PlayerPrefs.SetInt("LevelScore", 0);
		bestScoreDisplay.GetComponent<Text>().text = "BEST SCORE: " + bestScore;
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}
	public void Home()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public void BtnAudio_press()
	{
		if (AudioPanel.activeInHierarchy)
		{
			AudioPanel.SetActive(false);
		}
		else
		{
			AudioPanel.SetActive(true);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	//audio
	public void ChangeVolume()
	{
		AudioListener.volume = volumesider.value;
		Save();
	}

	public void Save()
	{
		PlayerPrefs.SetFloat("MusicVolume", volumesider.value);
	}
	public void Load()
	{
		volumesider.value = PlayerPrefs.GetFloat("MusicVolume");
	}
}
