using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
	public GameObject HintTriggetControlLayout;
	private int ToNextParagraph = 0;

	public void ReadyToExitTriggerActivation()
	{
		GetComponent<Animator>().SetBool("ReadyToExit", true);
	}

	public void ReadyToNextParagraph()
	{
		GetComponent<Animator>().SetInteger("ReadyToNextParagraph", GetComponent<Animator>().GetInteger("ReadyToNextParagraph") + 1);
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

	private void Start()
	{
		if (!PlayerPrefs.HasKey("FirstLevelLaunch"))
		{
			FindObjectOfType<PlayerMovement>().enabled = false;
			FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Rigidbody>().isKinematic = true;
			FindObjectOfType<CameraBodyMovement>().enabled = false;
			HintTriggetControlLayout.SetActive(false);
		}
		else
		{
			GetComponent<Animator>().enabled = false;
			this.gameObject.SetActive(false);
		}
	}
	public void MovementActivation()
	{
		FindObjectOfType<PlayerMovement>().enabled = true;
		HintTriggetControlLayout.SetActive(true);
		PlayerPrefs.SetInt("FirstLevelLaunch", 1);
		Cursor.visible = false;
	}
	public void CameraBodyActivation()
	{
		FindObjectOfType<CameraBodyMovement>().enabled = true;
		FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Rigidbody>().isKinematic = false;
	}
}
