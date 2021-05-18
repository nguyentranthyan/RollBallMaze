using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public BallMovement ball;
	public SpriteRenderer thers;
	public Sprite doorOpenSprite;
	public bool doorOpen, waittingOpen;
	public GameObject effect;
	private void Start()
	{
		ball = FindObjectOfType<BallMovement>();
	}
	private void Update()
	{
		if (waittingOpen)
		{
			if (Vector3.Distance(ball.followingKey.transform.position, transform.position) < 0.1f)
			{
				waittingOpen = false;
				doorOpen = true;
				thers.sprite = doorOpenSprite;
				ball.followingKey.gameObject.SetActive(false);
				ball.followingKey = null;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (ball.followingKey != null)
			{
				ball.followingKey.target = transform;
				waittingOpen = true;
				effect.SetActive(false);

			}
		}
	}
}
