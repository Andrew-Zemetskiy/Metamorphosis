using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPassingResult : MonoBehaviour
{
	public int ButtonToLevel;

	public Image CubeImage;
	public TMP_Text CubesCollected;
	public TMP_Text LevelNumber;
	public Image[] Stars;

	private string currentLvl;
	private int cubesQuantity;

	void Start()
	{
		//кол-во кубов на уровне
		currentLvl = $"Lvl{ButtonToLevel}-"; //Для поиска данных сцены внутри хранилища
		cubesQuantity = PlayerPrefs.GetInt(currentLvl + "CubesQuantity");
		//Звезды
		foreach (Image im in Stars) //все звезды неактивны
		{
			im.color = new Color(0.5411765f, 0.5411765f, 0.5411765f, 1f); //цвет неактивной звезды
		}
		for (int i = 0; i < PlayerPrefs.GetInt(currentLvl + "Mark"); i++)
		{
			Stars[i].color = new Color(1f, 1f, 1f, 1f); //цвет активной звезды
		}
		if (cubesQuantity == 0)
		{
			foreach (Image im in Stars)
			{ 
				im.gameObject.SetActive(false);
			}
		}

		//Кубы
		CubesCollected.text = PlayerPrefs.GetInt(currentLvl + "Cubes") + "/" + cubesQuantity;

		if (ButtonToLevel != 1) //если не первый уровень
		{
			CubeImage.gameObject.SetActive(false);
			CubesCollected.gameObject.SetActive(false);
			GetComponent<Button>().interactable = false;
			LevelNumber.color = new Color(0.4716981f, 0.4716981f, 0.4716981f, 1f);

			if (PlayerPrefs.GetInt($"Lvl{ButtonToLevel - 1}-Mark") > 0) //если предыдущий уровень был пройден
			{
				if (cubesQuantity != 0)
				{
					CubeImage.gameObject.SetActive(true);
					CubesCollected.gameObject.SetActive(true);
				}
				GetComponent<Button>().interactable = true;
				LevelNumber.color = new Color(1f, 1f, 1f, 1f);
			}
		}
		else
		{
			if (cubesQuantity == 0)
			{
				CubeImage.gameObject.SetActive(false);
				CubesCollected.gameObject.SetActive(false);
			}
		}
	}
}
