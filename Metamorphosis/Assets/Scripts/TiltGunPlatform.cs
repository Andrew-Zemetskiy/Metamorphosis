using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltGunPlatform : MonoBehaviour
{
	public string IncreaseOrDecrease = "Increase";
	public GameObject TiltGun;
	TiltGun tiltGun;

	private void Start()
	{
		tiltGun = TiltGun.GetComponent<TiltGun>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Equals("Player"))
		{
			tiltGun.Changes = IncreaseOrDecrease; //Increase или Decrease
			tiltGun.Invoke("СhangingRotation", 0f);
		}
	}
}
