using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	[SerializeField] private int numberscene;
	public GameObject levelTime;
	public GameObject levelScore;
	public GameObject nextLevel;
	public GameObject timeleft;
	public GameObject theScore;
	public GameObject totalScored;
	public int timeCalc;
	public int scoreCalc;
	public int totalScore;
	public int scoreStars;
	public int highscore;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		timeCalc = GolbalTimer.extendScore * 100;
		timeleft.GetComponent<Text>().text="Time Left : "+ GolbalTimer.extendScore+"x 100";
		theScore.GetComponent<Text>().text = "Score : " + Score.currentScore;
		totalScore = Score.currentScore + timeCalc;
		totalScored.GetComponent<Text>().text = "Total Score : " + totalScore;
		highscore = totalScore;
		scoreStars = totalScore;

		if (PlayerPrefs.GetInt("LevelScore")<= highscore)
		{
			PlayerPrefs.SetInt("LevelScore", highscore);
		}

		if (collision.gameObject.CompareTag("Player"))
		{
			levelTime.SetActive(false);
			levelScore.SetActive(false);
			Score.currentScore = totalScore;
			StartCoroutine(calculatorScore());	
		}
	}

	IEnumerator calculatorScore()
	{
		nextLevel.SetActive(true);
		timeleft.SetActive(true);
		yield return new WaitForSeconds(1f);
		theScore.SetActive(true);
		yield return new WaitForSeconds(1f);
		totalScored.SetActive(true);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(numberscene);
	}
}
