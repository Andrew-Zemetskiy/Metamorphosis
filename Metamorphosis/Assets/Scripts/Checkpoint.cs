using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
	private string obj;
	public Material defaultMaterial;
	public Material checkMaterial;
	private GameObject[] Checkpoints;

	private void Start()
	{
		obj = "CurLvl-Pos";//Для поиска данных сцены внутри хранилища
		this.GetComponent<MeshRenderer>().material = defaultMaterial;
		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Equals("Player"))
		{
			Vector3 pos = transform.position; //сохранение позиции
			PlayerPrefs.SetString($"{obj}X", pos.x.ToString());
			PlayerPrefs.SetString($"{obj}Y", collision.collider.transform.position.y.ToString());
			PlayerPrefs.SetString($"{obj}Z", pos.z.ToString());

			PlayerPrefs.SetInt("CurSavedCubes", PlayerPrefs.GetInt("CurrentCubesNumber")); //сохранение кол-ва кубов на чекпоинте
			//всем временно собранным кубам статус постоянных
			Checkpoints = GameObject.FindGameObjectsWithTag("Cube");
			foreach (GameObject go in Checkpoints)
			{
				if (go.GetComponent<CubeRotation>().isTaken)
				{
					go.GetComponent<CubeRotation>().isTaken = false;
				}
			}

			GameObject[] allCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint"); //замена цвета всех чекпоинтов на дефолтный
			foreach (GameObject g in allCheckpoints)
			{
				g.GetComponent<MeshRenderer>().material = defaultMaterial;
			}
			this.GetComponent<MeshRenderer>().material = checkMaterial;
		}
	}

	private void Update()
	{
		//if (Input.GetKey("p"))
		//{
		//	GameObject go = GameObject.FindGameObjectWithTag("Player");

		//	go.GetComponent<Rigidbody>().isKinematic = true;
		//	go.GetComponent<Transform>().position = new Vector3(float.Parse(PlayerPrefs.GetString($"{obj}x")), float.Parse(PlayerPrefs.GetString($"{obj}y")), float.Parse(PlayerPrefs.GetString($"{obj}z")));
		//	go.GetComponent<Rigidbody>().isKinematic = false;
		//}
	}
}
