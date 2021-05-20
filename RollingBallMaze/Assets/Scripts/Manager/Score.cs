using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public static int currentScore;
	public int internalScore;

	// Update is called once per frame
	void Update()
	{
		internalScore = currentScore;
		scoreText.GetComponent<TextMeshProUGUI>().text ="Score: "+ internalScore;

	}

}
