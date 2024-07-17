using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlatform : MonoBehaviour
{
	//Движующаяся платформа
	public GameObject TargetPosition;
	public float Speed;
	public float PauseTime; //время паузы платформы

	private float Timer; //обратный отсчет паузы
	private Vector3 StartPos;
	private Vector3 FinalPos;
	
	private Vector3 heading;
	private float distance;
	private Vector3 direction;

	private void Start()
	{
		Timer = PauseTime;
		StartPos = transform.position; //начальная платформа
		FinalPos = TargetPosition.GetComponent<Transform>().position; //целевая

		heading = StartPos - FinalPos; //разница точек float
		distance = heading.magnitude; //модуль между двумя позициями float
		direction = heading / distance; // нормализицированное направление Vector3

		GetComponent<AudioSource>().volume = FindObjectOfType<LevelSound>().soundEffectsFloat/10;
	}

	void FixedUpdate()
	{		
		if (Timer > 0)
		{
			Timer -= Time.deltaTime;
			GetComponent<AudioSource>().Stop();
		}
		else
		{
			MovementDirection();

			if (!GetComponent<AudioSource>().isPlaying) //играет ли аудио при передвижении
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
	public void TimerStart()
	{
		Timer = PauseTime;
	}

	public void TranslatePos()
	{
		transform.Translate(direction.x * Speed * Time.deltaTime, direction.y * Speed * Time.deltaTime, direction.z * Speed * Time.deltaTime, Space.World);
	}

	public void ChangeDirection()
	{
		Speed = -Speed;
		TranslatePos();
		TranslatePos();
		TimerStart();
	}

	public void MovementDirection()
	{
		if (direction.x < 0) //Целевая платформа расположена по оси Х
		{
			if (transform.position.x < StartPos.x || FinalPos.x < transform.position.x)
			{
				ChangeDirection();
			}
		}
		else if (direction.x > 0) //Целевая платформа расположена против оси Х
		{
			if (transform.position.x > StartPos.x || FinalPos.x > transform.position.x)
			{
				ChangeDirection();
			}
		}
		else //Целевая платформа - вертикальный лифт, x = 0
		{
			if (direction.y > 0) //целевая платформа ниже
			{
				if (transform.position.y > StartPos.y || FinalPos.y > transform.position.y)
				{
					ChangeDirection();
				}
			}
			else if (direction.y < 0) //целевая платформа выше
			{
				if (transform.position.y < StartPos.y || FinalPos.y < transform.position.y)
				{
					ChangeDirection();
				}
			}
			else //платформа по оси z, x = 0, y = 0 
			{
				if (direction.z > 0) //целевая платформа по оси Z
				{
					if (transform.position.z > StartPos.z || FinalPos.z > transform.position.z)
					{
						ChangeDirection();
					}
				}
				else //целевая платформа против оси Z
				{
					if (transform.position.z < StartPos.z || FinalPos.z < transform.position.z)
					{
						ChangeDirection();
					}
				}
			}
		}
		TranslatePos();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			GetComponent<AudioSource>().mute = false;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			GetComponent<AudioSource>().mute = true;
	}
}