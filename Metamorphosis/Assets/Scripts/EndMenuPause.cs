using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuPause : MonoBehaviour
{
	public TMP_Text PressAnyKeyForEpilogue;
	public Button ToMenu;
	public Button NextLvl;
	public Button RestartLvl;
	public GameObject Epilogue;
	private bool PressAnyButton;
	//Пауза конца уровня
	public void TimeStop()
	{
		Time.timeScale = 0f; //пауза
	}
	public void EpiloguePressAnyButtonIndentification()
	{
		PressAnyButton = true;
	}
	private void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 5)
		{
			NextLvl.gameObject.SetActive(false);
			if (!PlayerPrefs.HasKey("FirstLastLevelLaunch"))
			{
				ToMenu.gameObject.SetActive(false);
				RestartLvl.gameObject.SetActive(false);
				PressAnyKeyForEpilogue.gameObject.SetActive(true);
			}
		}
	}

	private void Update()
	{
		if (PressAnyButton && !PlayerPrefs.HasKey("FirstLastLevelLaunch"))
		{
			if (Input.anyKeyDown)
			{
				Time.timeScale = 1f; //пауза
				PressAnyButton = false;
				Epilogue.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
	}
}
