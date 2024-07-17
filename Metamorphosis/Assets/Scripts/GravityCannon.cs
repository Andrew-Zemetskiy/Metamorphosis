using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCannon : MonoBehaviour
{
	//пусковая уставнока
	public float power = 2f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.VelocityChange);
		}
	}
}
