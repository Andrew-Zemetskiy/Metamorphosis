using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
	//перезапуск и завершение уровня
	public float restartDelay = 1f;
	public GameObject completeLevelUI;

	private GameObject Player;
	private string obj;
	private GameObject[] Checkpoints;
	[SerializeField]
	private GameObject Prologue;

	private void Start()
	{
		obj = "CurLvl-Pos";//Для поиска данных сцены внутри хранилища
		Player = GameObject.FindGameObjectWithTag("Player");
		if (!PlayerPrefs.HasKey("FirstLevelLaunch"))
		{
			Prologue.GetComponent<Animator>().enabled = true;
			Prologue.SetActive(true);
		}
	}
	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true); //запуск экрана конца уровня
		FindObjectOfType<GameInterface>().PrintLevelResults(); //вывод результатов и их сохранение
		Cursor.visible = true;
	}
	public void MinusLife()
	{
		if (PlayerPrefs.GetInt("CurrentLives") - 1 <= 0)
		{
			Restart();
		}
		PlayerPrefs.SetInt("CurrentLives", PlayerPrefs.GetInt("CurrentLives") - 1);
		ReturnToCheckpoint();
	}

	public void ReturnToCheckpoint()
	{
		PlayerPrefs.SetInt("CurrentCubesNumber", PlayerPrefs.GetInt("CurSavedCubes")); //установка сохраненного кол-ва кубов

		Player.GetComponent<Rigidbody>().isKinematic = true;
		Player.GetComponent<Transform>().position = new Vector3(float.Parse(PlayerPrefs.GetString($"{obj}X")), float.Parse(PlayerPrefs.GetString($"{obj}Y")), float.Parse(PlayerPrefs.GetString($"{obj}Z")));
		Player.GetComponent<Rigidbody>().isKinematic = false;

		//возвращение всех несохраненных кубов
		Checkpoints = GameObject.FindGameObjectsWithTag("Cube");
		foreach (GameObject go in Checkpoints)
		{
			if (go.GetComponent<CubeRotation>().isTaken)
			{
				go.GetComponent<Collider>().enabled = true;
				go.GetComponent<MeshRenderer>().enabled = true;
				go.GetComponent<CubeRotation>().isTaken = false;
			}
		}

		ResetProgressOfMadnessAchievement();
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadNextLevel()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
	}

	public void ToMenu()
	{
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1f;
	}

	public void ResetProgressOfMadnessAchievement()
	{
		string srt = string.Join(",", FindObjectOfType<GameInterface>().WhatMadnessIs.Select(n => false));
		PlayerPrefs.SetString("WhatMadnessIs", string.Join(",", srt));
		FindObjectOfType<GameInterface>().WhatMadnessIs = PlayerPrefs.GetString("WhatMadnessIs").Split(',').Select(n => Convert.ToBoolean(n)).ToArray();
	}
}
