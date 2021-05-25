using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
	[SerializeField] private GameObject m_SettingPanel;
	
	public void BtnSetting_press()
	{
		if (!m_SettingPanel.activeInHierarchy)
		{
			m_SettingPanel.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			m_SettingPanel.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}
