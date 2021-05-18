using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleEnter : MonoBehaviour
{
	public Transform m_HoleExit;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.transform.position = m_HoleExit.position;
		}
	}
}
