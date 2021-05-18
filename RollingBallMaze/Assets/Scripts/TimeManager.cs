using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	public static TimeManager instance;

	private void Awake()
	{
		instance = this;
	}

	public GameObject timeDisplay;
	public bool isTimeRun = false;//check time run
	public int theSeconds = 150;
	public static int extendSeconds;

	// Update is called once per frame
	void Update()
	{
		extendSeconds = theSeconds;
		if (isTimeRun == false)
		{
			StartCoroutine(SubtractSecond());
		}
	}

	//trừ thời gian 1s từ 150s
	IEnumerator SubtractSecond()
	{
		isTimeRun = true;
		theSeconds -= 1;
		timeDisplay.GetComponent<Text>().text = "" + theSeconds;
		yield return new WaitForSeconds(1);
		isTimeRun = false;
	}
}
