using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
	//вращения кубов
	public Vector3 CubeRotat = new Vector3(1, 0, 0); //X ось
	public float RotatSpeed = 1f;
	float Angle;
	Quaternion OriginalRotation;
	public bool isTaken;

	void Start()
	{
		OriginalRotation = transform.rotation;
		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat;
		isTaken = false; //статус по умолчанию
	}

	void FixedUpdate()
	{
		Angle++;
		Quaternion rotationX = Quaternion.AngleAxis(Angle * RotatSpeed * 3, new Vector3(CubeRotat.x, 0, 0)); //раздельные повороты для x и y, для независимого вращения
		Quaternion rotationY = Quaternion.AngleAxis(Angle * RotatSpeed, new Vector3(0, CubeRotat.y, 0));
		transform.rotation = OriginalRotation * rotationY * rotationX;
	}
}
