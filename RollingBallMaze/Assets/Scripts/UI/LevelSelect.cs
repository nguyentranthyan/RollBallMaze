using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
	public GameObject levelHolder;
	public GameObject levelIcon;
	public int numberOfLevels=50;

	// Start is called before the first frame update
	void Start()
    {
		Rect panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
		Rect iconDimensions = levelHolder.GetComponent<RectTransform>().rect;
		int maxInArrows = Mathf.FloorToInt(panelDimensions.width/iconDimensions.width);
		int maxInACol = Mathf.FloorToInt(panelDimensions.height / iconDimensions.height);
		int amountPerPage = maxInACol * maxInArrows;
		int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
		loadPanel(totalPages);
	}

	private void loadPanel(int totalPages)
	{
		GameObject panelClone = Instantiate(levelHolder) as GameObject;
		for(int i=0; i < numberOfLevels; i++)
		{
			GameObject panel = Instantiate(panelClone) as GameObject;
			panel.transform.SetParent(levelHolder.transform);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
