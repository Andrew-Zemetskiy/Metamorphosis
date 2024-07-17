using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzlePowerActivation : MonoBehaviour
{
    public GameObject TiltGun;
    TiltGun tiltGun;
    void Start()
    {
        tiltGun = TiltGun.GetComponent<TiltGun>();
		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat;
	}

	//активация скрипта при наезде на коллайдер в роли триггера
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			tiltGun.Invoke("PowerActivation", 0f);
		}
	}
}
