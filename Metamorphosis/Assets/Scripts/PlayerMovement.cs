using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Движение игрока
	private GameObject CameraBody;

	private Rigidbody rb;
	[SerializeField]
	private float WoodSpeed = 1500f;
	[SerializeField]
	private float StoneSpeed = 2400f;
	private float Speed;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		CameraBody = GameObject.FindGameObjectWithTag("CameraBody");
	}

	private void FixedUpdate()
	{
		MaterialDefinition();

		//перемещение камеры, относительно которой и происходит движение игрока
		if (Input.GetKey(PlayerPrefs.GetString("Key-forward"))) //получение кнопки движения вперед, исходя из сохраненной раскладки
		{
			rb.AddForce(CameraBody.transform.forward * Speed * Time.deltaTime);
		}
		if (Input.GetKey(PlayerPrefs.GetString("Key-back")))
		{
			rb.AddForce(-CameraBody.transform.forward * Speed * Time.deltaTime);
		}
		if (Input.GetKey(PlayerPrefs.GetString("Key-left")))
		{
			rb.AddForce(-CameraBody.transform.right * Speed * Time.deltaTime);
		}
		if (Input.GetKey(PlayerPrefs.GetString("Key-right")))
		{
			rb.AddForce(CameraBody.transform.right * Speed * Time.deltaTime);
		}
		if (transform.position.y < -2f) //смерть
		{
			FindObjectOfType<GameManager>().MinusLife();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<AudioSource>())
		{
			other.GetComponent<AudioSource>().Play();
			if (other.tag.Equals("Cube"))
			{
				//Destroy(other.gameObject);
				other.gameObject.GetComponent<CubeRotation>().isTaken = true; //если взял куб
				other.enabled = false;
				other.GetComponent<MeshRenderer>().enabled = false;
				PlayerPrefs.SetInt("CurrentCubesNumber", PlayerPrefs.GetInt("CurrentCubesNumber") + 1);
			}
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.GetComponent<AudioSource>())
		{
			collision.collider.GetComponent<AudioSource>().Play();
		}
	}


	public void MaterialDefinition()
	{
		string a = GetComponent<Renderer>().material.name;
		a = a.Substring(0, a.Length - 11);
		if (a == "Wood035")
		{
			Speed = WoodSpeed;
		}
		else if (a == "Rock28")
		{
			Speed = StoneSpeed;
		}
	}
	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.collider.CompareTag("MovePlatform"))
	//	{
	//		Player.transform.parent = collision.transform;
	//	}
	//}

	//private void OnCollisionExit(Collision collision)
	//{
	//	if (collision.collider.CompareTag("MovePlatform"))
	//	{
	//		Player.transform.parent = null;
	//	}
	//}
}
