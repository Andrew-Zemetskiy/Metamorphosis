using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
	public GameManager gameManager;
	private string obj;
	private GameObject go;

	private void Start()
	{
		obj = $"PosLvl{SceneManager.GetActiveScene().buildIndex}";
		go = GameObject.FindGameObjectWithTag("Player");
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			if (PlayerPrefs.GetInt("Lives") - 1 <= 0)
			{
				//Debug.Log(PlayerPrefs.GetInt("Lives") - 1);
				gameManager.Restart();
			}
			PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);

			GameObject go = GameObject.FindGameObjectWithTag("Player");
			go.GetComponent<Rigidbody>().isKinematic = true;
			go.GetComponent<Transform>().position = new Vector3(float.Parse(PlayerPrefs.GetString($"{obj}x")), float.Parse(PlayerPrefs.GetString($"{obj}y")), float.Parse(PlayerPrefs.GetString($"{obj}z")));
			go.GetComponent<Rigidbody>().isKinematic = false;
			
		}
	}
}
