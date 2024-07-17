using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltGun : MonoBehaviour
{
	public GameObject GunMuzzle;
	public GameObject GreenPlatform;
	public GameObject RedPlatform;
	GameObject Player;

	public Quaternion OriginalRotation;
	public Quaternion TargetRotation;
	public string Changes;
	public float MaxAngle = 30;
	public float MinAngle = 10;
	public float angleStep = 10;
	public float rotationSpeed = 10f;

	public float startRotationX;
	public float targetAngle;
	float currentAngle;
	float angle;
	public bool Power = true;
	public float Force = 20f;

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		OriginalRotation = GunMuzzle.transform.rotation;
		OriginalRotation = Quaternion.Euler(MinAngle, OriginalRotation.eulerAngles.y, OriginalRotation.eulerAngles.z);
		targetAngle = GunMuzzle.transform.eulerAngles.x; //стартовое значение целевого угла
		startRotationX = OriginalRotation.eulerAngles.x; //стандартное значение х по минимуму
		angle = GunMuzzle.transform.eulerAngles.x - MinAngle; //разница между минимальным градусом х и начальным х
		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat;
	}

	public void PowerActivation()
	{
		Player.GetComponent<Rigidbody>().AddForce(-transform.forward * Force, ForceMode.VelocityChange); //сила по направлению дула пушки
	}

	public void СhangingRotation()
	{
		if (Changes == "Decrease") angleStep = -Mathf.Abs(angleStep);
		else angleStep = Mathf.Abs(angleStep);
		targetAngle += angleStep;
		targetAngle = Mathf.Clamp(targetAngle, MinAngle, MaxAngle);
	}
	private void FixedUpdate()
	{
		currentAngle = GunMuzzle.transform.eulerAngles.x;
		if (currentAngle < targetAngle - Time.deltaTime || currentAngle > targetAngle + Time.deltaTime)
		{
			if (!GetComponent<AudioSource>().isPlaying) //играет ли аудио вращения
			{
				GetComponent<AudioSource>().Play();
			}
			if (currentAngle > targetAngle + Time.deltaTime)
			{
				angle -= rotationSpeed * Time.deltaTime; //скорость вращения
			}
			else if (currentAngle < targetAngle - Time.deltaTime)
			{
				angle += rotationSpeed * Time.deltaTime; //скорость вращения
			}

			angle = Mathf.Clamp(angle, MinAngle - startRotationX, MaxAngle - startRotationX); //ограничения для добавляемого поворота

			Quaternion rotationX = Quaternion.AngleAxis(angle, Vector3.right);
			GunMuzzle.transform.rotation = OriginalRotation * rotationX; //добавление вращения к минимальному
		}
		else
		{
			GetComponent<AudioSource>().Stop();
		}
	}
}
