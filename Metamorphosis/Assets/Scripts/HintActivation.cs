using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HintActivation : MonoBehaviour
{
	public GameObject HintInterface;
	public Animator anim;

	public Image HintImage1;
	public Sprite HintImageContent1;
	public Image HintImage2;
	public Sprite HintImageContent2;
	public TextMeshProUGUI HintText;
	public string HintTextContent;

	private void OnTriggerEnter(Collider other)
	{
		HintText.text = HintTextContent;
		HintImage1.sprite = HintImageContent1;
		HintImage2.sprite = HintImageContent2;
		HintInterface.SetActive(true);
	}
}
