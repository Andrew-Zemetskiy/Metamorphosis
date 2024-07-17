using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAnimation : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            anim.Play("HintOpen");
        }
        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("ReadyToClose", true);
        }
    }
}
