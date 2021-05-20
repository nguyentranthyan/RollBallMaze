using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject bestScoreDisplay;
	public int bestScore;

	private void Start()
	{
		bestScore = PlayerPrefs.GetInt("LevelScore");
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
	
	public void QuitGame()
	{
		Application.Quit();
	}
	public void ResetBest()
	{
		PlayerPrefs.SetInt("LevelScore", 0);
		bestScoreDisplay.GetComponent<Text>().text = "BEST SCORE: " + bestScore;
	}
}
