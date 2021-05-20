using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GolbalTimer : MonoBehaviour
{
	public TextMeshProUGUI timeText;
	public bool timerIsRunning = false;
	public int theSeconds = 180;
	public static int extendScore;
	public GameObject gameover;

	private void Start()
	{
		gameover.SetActive(false);
	}
	void Update()
	{
		extendScore = theSeconds;
		if (timerIsRunning == false)
		{
			StartCoroutine(DisplayTime());
		}
		if (theSeconds == 0)
		{
			Score.currentScore = 0;
			StartCoroutine(DisplayGameOver());
			
		}
	}
	IEnumerator DisplayGameOver()
	{
		gameover.SetActive(true);
		yield return new WaitForSeconds(3f);
		GameManager.instance.Home();
	}

	IEnumerator DisplayTime()
	{
		timerIsRunning = true;
		theSeconds -= 1;
		timeText.GetComponent<TextMeshProUGUI>().text="Time: "+ theSeconds + "s";
		yield return new WaitForSeconds(1);
		timerIsRunning = false;
	}
}
