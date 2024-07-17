using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
	//Смена материала
	public string PlatformMaterial = "Stone";
	public Material StoneMaterial;
	public PhysicMaterial StonePhysicMaterial;
	public float StoneMass;

	public Material WoodMaterial;
	public PhysicMaterial WoodPhysicMaterial;
	public float WoodMass;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
		{
			if (PlatformMaterial == "Stone")
			{
				collision.collider.GetComponent<MeshRenderer>().material = StoneMaterial;
				collision.collider.GetComponent<Collider>().material = StonePhysicMaterial;
				collision.collider.GetComponent<Rigidbody>().mass = StoneMass;
			}
			else if(PlatformMaterial == "Wood")
			{
				collision.collider.GetComponent<MeshRenderer>().material = WoodMaterial;
				collision.collider.GetComponent<Collider>().material = WoodPhysicMaterial;
				collision.collider.GetComponent<Rigidbody>().mass = WoodMass;
			}
		}
	}
}
