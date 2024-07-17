using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
	//срабатывание тригера конца уровня
	private void Start()
	{
		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat;
	}

	private void OnCollisionEnter(Collision collision)
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
		FindObjectOfType<GameManager>().CompleteLevel();
	}
}
