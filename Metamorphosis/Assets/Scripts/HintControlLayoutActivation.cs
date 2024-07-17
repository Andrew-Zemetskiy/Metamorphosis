using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HintControlLayoutActivation : MonoBehaviour
{
	public GameObject HintInterface;
	public Animator anim;

	public TextMeshProUGUI HintTextForward;
	public TextMeshProUGUI HintTextBackward;
	public TextMeshProUGUI HintTextLeft;
	public TextMeshProUGUI HintTextRight;

	private void Update()
	{
		//if (Timer > 0)
		//{
		//	Timer -= Time.deltaTime;
		//}
		//else
		//{
		//	HintInterface.SetActive(false);
		//}
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		HintTextForward.text = PlayerPrefs.GetString("Key-forward");
		HintTextBackward.text = PlayerPrefs.GetString("Key-back");
		HintTextLeft.text = PlayerPrefs.GetString("Key-left");
		HintTextRight.text = PlayerPrefs.GetString("Key-right");
		HintInterface.SetActive(true);
	}
}
