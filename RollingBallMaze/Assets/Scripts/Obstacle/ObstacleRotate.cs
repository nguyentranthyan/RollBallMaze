using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
	[SerializeField]private float m_BlockSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(new Vector3(0f,0f,1f * m_BlockSpeed * Time.deltaTime));
    }
}
