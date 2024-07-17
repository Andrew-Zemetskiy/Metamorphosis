using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Linq;

public class GameInterface : MonoBehaviour
{
	public TMP_Text cubsCounter;
	public TMP_Text livesCounter;
	public GameObject pauseMenu;
	public bool PauseGame;
	private int cubesQuantity;

	//Для финального меню
	public Text NumberOfCubes;
	public Text FinalMark;
	private string currentLvl;
	private static readonly string CubePref = "CurrentCubesNumber";
	private static readonly string LivePref = "CurrentLives";

	//Для достижений
	private Vector3 startPosOfPlayer;
	public bool[] WhatMadnessIs;

	private void Start()
	{
		startPosOfPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
		Cursor.visible = false; //отключение видимости курсора
		PlayerPrefs.SetInt(CubePref, 0);
		PlayerPrefs.SetInt(LivePref, 3); //кол-во жизней на уровне
		currentLvl = $"Lvl{SceneManager.GetActiveScene().buildIndex}-"; //Для поиска данных сцены внутри хранилища
		cubesQuantity = GameObject.FindGameObjectsWithTag("Cube").Length;
		PlayerPrefs.SetInt(currentLvl + "CubesQuantity", cubesQuantity); //сохранение сумарного кол-ва кубов
		//Для достижения
		WhatMadnessIs = new bool[7];
		if (!PlayerPrefs.HasKey("WhatMadnessIs"))
		{
			PlayerPrefs.SetString("WhatMadnessIs", string.Join(",", WhatMadnessIs));	
		}
		else
		{
			WhatMadnessIs = PlayerPrefs.GetString("WhatMadnessIs").Split(',').Select(n => Convert.ToBoolean(n)).ToArray();
		}
	}

	public void Update()
	{
		cubsCounter.text = "" + PlayerPrefs.GetInt(CubePref) + "/" + cubesQuantity;
		livesCounter.text = "X " + PlayerPrefs.GetInt(LivePref);

		if (Input.GetKeyDown(KeyCode.Escape) && PlayerPrefs.HasKey("FirstLevelLaunch"))
		{
			if (PauseGame)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	//Итоговый экран уровня
	public void PrintLevelResults()
	{
		//Вывод на экран количества кубов с их сохранением
		NumberOfCubes.text = "Кубов собрано:" + PlayerPrefs.GetInt(CubePref) + "/" + cubesQuantity;
		if (PlayerPrefs.GetInt(currentLvl + "Cubes") < PlayerPrefs.GetInt(CubePref)) { PlayerPrefs.SetInt(currentLvl + "Cubes", PlayerPrefs.GetInt(CubePref)); }

		//Оценка от 1 до 3 по количеству жизней и вывод
		int Mark = PlayerPrefs.GetInt(LivePref);
		FinalMark.text = "Оценка прохождения: ";
		//if (lifes >= 6) { Mark = 3; }
		//else if (3 <= lifes && lifes <= 5) { Mark = 2; }
		//else { Mark = 1; }
		FinalMark.text += Mark.ToString();
		//сохранение лучшего результата
		if (PlayerPrefs.GetInt(currentLvl + "Mark") < Mark) { PlayerPrefs.SetInt(currentLvl + "Mark", Mark); }

		//получение достижений
		GettingAchievements();
	}

	public void GettingAchievements()
	{
		//достижение "И так сойдет"
		if (PlayerPrefs.GetInt(CubePref) == 0) //собранное кол-во кубов = 0
		{
			PlayerPrefs.SetInt("Achievement:ZeroCubes", 1);
		}
		//достижение "Катающийся по лезвию"
		if (PlayerPrefs.GetInt(LivePref) == 1)
		{
			PlayerPrefs.SetInt("Achievement:OneLife", 1);
		}
		//достижение "Слишком просто"
		if (PlayerPrefs.GetInt(currentLvl + "Mark") == 3)
		{
			PlayerPrefs.SetInt("Achievement:TooEasy", 1);
		}
		//достижение "Сразу или никак"
		float x = float.Parse(PlayerPrefs.GetString("CurLvl-PosX"));
		float y = float.Parse(PlayerPrefs.GetString("CurLvl-PosY"));
		float z = float.Parse(PlayerPrefs.GetString("CurLvl-PosZ"));
		if (Mathf.Abs(startPosOfPlayer.x - x) < 3 && Mathf.Abs(startPosOfPlayer.y - y) < 3 && Mathf.Abs(startPosOfPlayer.z - z) < 3)
		{
			PlayerPrefs.SetInt("Achievement:ImmediatelyOrInNoWay", 1);
		}
		//достижение "Знаешь, что такое безумие?"
		if (PlayerPrefs.GetInt(currentLvl + "Mark") == 3)
		{
			WhatMadnessIs[SceneManager.GetActiveScene().buildIndex - 1] = true;
			string Str = string.Join(",", WhatMadnessIs);
			PlayerPrefs.SetString("WhatMadnessIs", Str);
		}
		else
		{
			for (int i = 0; i < WhatMadnessIs.Length; i++)
			{
				WhatMadnessIs[i] = false;
			}
			string Str = string.Join(",", WhatMadnessIs);
			PlayerPrefs.SetString("WhatMadnessIs", Str);
		}
	}

	//Функции для меню паузы
	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f; //время в нормальном режиме
		PauseGame = false;
		Cursor.visible = false; //отключение видимости курсора
	}

	public void Pause()
	{
		Cursor.visible = true; //включение видимости курсора
		pauseMenu.SetActive(true);
		Time.timeScale = 0f; //пауза
		PauseGame = true;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}
}
