using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	public GameObject Pref;
	private Rigidbody rb;
	private Vector3 startPosition; //начальная позиция платформы
	private Quaternion startRotation;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		startPosition = transform.position;
		startRotation = GetComponent<Transform>().rotation;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Equals("Player"))
		{
			rb.isKinematic = false;

			Invoke("ReturnToStartPosition", 5f);
		}
	}
	void ReturnToStartPosition()
	{
		rb.isKinematic = true;
		transform.position = startPosition;
		//transform.rotation = Quaternion.identity; //сброс поворота
		transform.rotation = startRotation;
	}
}
