using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Epilogue : MonoBehaviour
{
	private int ToNextParagraph = 0;

	public void ReadyToExitTriggerActivation()
	{
		GetComponent<Animator>().SetBool("ReadyToExit", true);
	}

	public void ReadyToNextParagraph()
	{
		GetComponent<Animator>().SetInteger("ReadyToNextParagraph", GetComponent<Animator>().GetInteger("ReadyToNextParagraph") + 1);
	}

	private void Start()
	{
		if (!PlayerPrefs.HasKey("FirstLastLevelLaunch"))
		{
			FindObjectOfType<PlayerMovement>().enabled = false;
			FindObjectOfType<CameraBodyMovement>().enabled = false;
			PlayerPrefs.SetInt("FirstLastLevelLaunch", 1);
			GameObject.FindGameObjectWithTag("MusicInTheGame").GetComponent<AudioSource>().enabled = false;
		}
		else
		{
			GetComponent<Animator>().enabled = false;
			this.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (Input.anyKeyDown && ToNextParagraph + 1 == GetComponent<Animator>().GetInteger("ReadyToNextParagraph"))
		{
			GetComponent<Animator>().SetTrigger("DownloadNextParagraph");
			ToNextParagraph++;
		}
	}

	public void CloseAnim()
	{
		GetComponent<Animator>().enabled = false;
		this.gameObject.SetActive(false);
	}

	public void ToMenu()
	{
		SceneManager.LoadScene("Menu");
		Cursor.visible = true;
	}
}
