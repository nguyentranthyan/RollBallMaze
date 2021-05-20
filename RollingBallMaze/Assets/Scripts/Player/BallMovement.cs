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
	[SerializeField] private float m_speed;
	public Joystick m_JoystickchangeMove;
	public Transform startPosition;

    // Start is called before the first frame update
    void Start()
    {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Animator = GetComponent<Animator>();
		transform.position = startPosition.position;
	}

    // Update is called once per frame
    void Update()
    {
		m_ChangeMove.x = Input.GetAxisRaw("Horizontal");
		m_ChangeMove.y = Input.GetAxisRaw("Vertical");
		BallMove();
		m_ChangeMove.Normalize();
	}
	private void BallMove()
	{
		//Normal
		m_ChangeMove = new Vector2(m_ChangeMove.x, m_ChangeMove.y);
		//Joystick
		m_ChangeMove = new Vector2(m_JoystickchangeMove.Horizontal, m_JoystickchangeMove.Vertical);

		if(m_ChangeMove.x > 0 || m_ChangeMove.x < 0 || m_ChangeMove.y < 0 || m_ChangeMove.y > 0)
		{
			
			m_Rigidbody2D.AddForce(m_ChangeMove * m_speed * Time.deltaTime);
			m_Animator.SetBool("Move", true);
		}
		else
		{
			m_Rigidbody2D.velocity = Vector3.zero;
			m_Animator.SetBool("Move", false);
		}	
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			Score.currentScore = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (collision.gameObject.CompareTag("Collect"))
		{
			Score.currentScore += 100;
			collision.gameObject.SetActive(false);
		}
	}
}
