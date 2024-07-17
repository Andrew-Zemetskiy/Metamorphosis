using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAnimationClose : MonoBehaviour
{
	private Animator anim;

	void Start()
	{
		anim = this.gameObject.GetComponent<Animator>();
	}

	public void OpeningOver(bool B)
	{
		anim.SetBool("OpeningOver", B);
	}

	public void AnimationClose()
	{
		this.gameObject.SetActive(false);
	}
}
