using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCameraMap : MonoBehaviour
{
	public GameObject m_MiniCamera;

    public void BtnMap_press()
	{
		if (!m_MiniCamera.activeInHierarchy)
		{
			m_MiniCamera.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			m_MiniCamera.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}
