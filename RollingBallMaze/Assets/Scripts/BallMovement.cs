using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallMovement : MonoBehaviour
{
	[SerializeField] private Animator m_Animator ;
	[SerializeField] private Rigidbody2D m_Rigidbody2D;

	[SerializeField] private Vector2 m_ChangeMove;
	public Joystick m_JoystickchangeMove;

	public Transform keyFollowPoint;
	public Key followingKey;

    // Start is called before the first frame update
    void Start()
    {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		m_ChangeMove.x = Input.GetAxisRaw("Horizontal");
		m_ChangeMove.y = Input.GetAxisRaw("Vertical");
		BallMove(); 
    }

	private void BallMove()
	{
		//Normal
		m_Rigidbody2D.velocity = new Vector2(m_ChangeMove.x, m_ChangeMove.y);
		
		//Joystick
		m_Rigidbody2D.velocity = new Vector2(m_JoystickchangeMove.Horizontal, m_JoystickchangeMove.Vertical);

		if(m_ChangeMove.x > 0 || m_ChangeMove.x < 0 
			|| m_ChangeMove.y < 0 || m_ChangeMove.y > 0)
		{
			m_Animator.SetTrigger("Roll");
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			SceneManager.LoadScene(4);
		}
	}
}
