using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
	public float Speed = 2f;
	float startPosition; //начальная позиция лифта
	public float targetPosition; //конечная

	private void Start()
	{
		startPosition = transform.position.z;
	}

	void Update()
	{
		if (transform.position.y <= startPosition || targetPosition < transform.position.y)
		{
			Speed = -Speed;		
		}
		transform.Translate(0, Speed * Time.deltaTime, 0, Space.Self);
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider.tag.Equals("Player"))
		{
			collision.collider.GetComponent<Transform>().Translate(0, Speed * Time.deltaTime, 0, Space.World);
		}
	}
}
