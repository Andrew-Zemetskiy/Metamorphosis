using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
	//платформа для прыжка
	public float UseMassPower = 2000f;
	public float IgnoreMassPower = 15f;
	//public float Power = 600f;
	public bool IgnoreMass;

	private void Start()
	{
		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (IgnoreMass)
		{
			collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * IgnoreMassPower, ForceMode.VelocityChange);
		}
		else
		{
			//collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * UseMassPower, ForceMode.Force);
			collision.collider.GetComponent<Rigidbody>().AddForce(transform.up * UseMassPower, ForceMode.Force);
		}
		//collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * Power, ForceMode.Force);
	}
}
