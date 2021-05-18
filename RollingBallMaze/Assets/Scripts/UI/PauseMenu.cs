using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
	[SerializeField] private bool m_GameIsPaused;
	[SerializeField] private GameObject m_PausePanel;

	public void Pause()
	{
		m_PausePanel.SetActive(true);
		Time.timeScale = 0f;
		m_GameIsPaused = true;
	}
	public void Resume()
	{
		m_PausePanel.SetActive(false);
		Time.timeScale = 1f;
		m_GameIsPaused = false;
	}
	public void Home()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
