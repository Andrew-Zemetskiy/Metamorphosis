using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class Achievements : MonoBehaviour
{
	public Button FirstAchieve;
	public Button SecondAchieve;
	public Button ThirdAchieve;
	public Button FourthAchieve;
	public Button FifthAchieve;
	public Button SixthAchieve;
	public Button SeventhAchieve;
	public Button EighthAchieve;

	private string currentLvl;
	private bool collection; //все ли кубы собраны?
	private bool perfectionist; //пройдены уровни на три звезды?
	private bool[] WhatMadnessIs = new bool[7];

	private void Start()
	{
		//первое достижение
		PlayerPrefs.SetInt("Achievement:TheBeginningOfTheJourney", 1);

		//второе достижение
		for (int i = 1; i < 7; i++)
		{
			currentLvl = $"Lvl{i}-";
			if (PlayerPrefs.HasKey(currentLvl + "Cubes") && PlayerPrefs.HasKey(currentLvl + "CubesQuantity") && PlayerPrefs.GetInt(currentLvl + "Cubes") == PlayerPrefs.GetInt(currentLvl + "CubesQuantity"))
			{
				collection = true;
			}
			else
			{
				collection = false;
				break;
			}
		}

		//для получения достижения "Перфекционист"
		if (collection)
		{
			for (int i = 1; i < 7; i++)
			{
				currentLvl = $"Lvl{i}-";
				if (PlayerPrefs.HasKey(currentLvl + "Mark") && PlayerPrefs.GetInt(currentLvl + "Mark") == 3)
				{
					perfectionist = true;
				}
				else
				{
					perfectionist = false;
					break;
				}
			}
		}

		if (collection)
		{
			PlayerPrefs.SetInt("Achievement:Collector", 1);
		}
		if (perfectionist)
		{
			PlayerPrefs.SetInt("Achievement:Perfectionist", 1);
		}

		WhatMadnessIs = PlayerPrefs.GetString("WhatMadnessIs").Split(',').Select(n => Convert.ToBoolean(n)).ToArray();
		if (!WhatMadnessIs.Contains(false))
		{
			PlayerPrefs.SetInt("Achievement:WhatMadnessIs", 1);
		}

		ButtonActivation(ref FirstAchieve, "Achievement:TheBeginningOfTheJourney");
		ButtonActivation(ref SecondAchieve, "Achievement:Collector");
		ButtonActivation(ref ThirdAchieve, "Achievement:ZeroCubes");
		ButtonActivation(ref FourthAchieve, "Achievement:OneLife");
		ButtonActivation(ref FifthAchieve, "Achievement:TooEasy");
		ButtonActivation(ref SixthAchieve, "Achievement:Perfectionist");
		ButtonActivation(ref SeventhAchieve, "Achievement:ImmediatelyOrInNoWay");
		ButtonActivation(ref EighthAchieve, "Achievement:WhatMadnessIs");
	}

	public void ButtonActivation(ref Button AchieveButton, string Achieve)
	{
		bool isReceived = PlayerPrefs.GetInt(Achieve) == 0 ? false : true; //получено ли достижение
		AchieveButton.interactable = isReceived; //статус активности
		foreach (TextMeshProUGUI TMP in AchieveButton.GetComponentsInChildren<TextMeshProUGUI>()) //окрашивание дочерних эл-ов
		{
			TMP.color = isReceived ? new Color32(255, 255, 255, 255) : new Color32(150, 150, 150, 255);
		}
	}
}
