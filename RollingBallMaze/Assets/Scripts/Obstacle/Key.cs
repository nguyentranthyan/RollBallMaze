using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	private bool isfollow;
	public float followSpeed;
	public Transform target;

    // Start is called before the first frame update
    void Start()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
		if (isfollow)
			transform.position = Vector3.Lerp(transform.position,target.transform.position,
				followSpeed*Time.deltaTime);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (!isfollow)
			{
				isfollow = true;
				BallMovement ball = FindObjectOfType<BallMovement>();
				target = ball.keyFollowPoint;
				ball.followingKey=this;
			}
		}
	}
}
