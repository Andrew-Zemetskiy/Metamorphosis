using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	void Start()
	{
		if (!PlayerPrefs.HasKey("Key-forward"))
		{
			PlayerPrefs.SetString("Key-forward", "w"); //forward
			PlayerPrefs.SetString("Key-back", "s");   //back
			PlayerPrefs.SetString("Key-left", "a");   //left
			PlayerPrefs.SetString("Key-right", "d"); //right
		}
	}

	public void PlayLevel(int level)
	{
		SceneManager.LoadScene(level); //SceneManager.GetActiveScene().buildIndex
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
