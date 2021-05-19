using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public float score;
	public float scoreDecreasePerSeconds;
	public float highScore;

	// Start is called before the first frame update
	void Start()
	{
		score = 1000f;
		scoreDecreasePerSeconds = 1f;
		highScore = PlayerPrefs.GetInt("HighScore", 0);
	}

	// Update is called once per frame
	void Update()
	{
		score -= scoreDecreasePerSeconds * Time.deltaTime;
		scoreText.text = "Score: " + (int)score;
		if (highScore < score)
		{
			PlayerPrefs.SetFloat("highscore", score);
		}
	}

}
