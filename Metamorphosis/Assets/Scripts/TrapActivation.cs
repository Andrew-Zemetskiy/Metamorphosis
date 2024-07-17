using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
	//Активация ловушки и генерация препятствий
	public GameObject ObjectOfDeactivation;
	public GameObject ObstaclePrefab;
	public GameObject GenerationArea;
	public int MinNumOfObjects;
	public int MaxNumOfObjects;
	public static int NumOfObjects = 1;

	private Vector3 minPos;
	private Vector3 maxPos;
	[SerializeField]
	private GameObject[] ArrObst;

	private void Start()
	{
		Transform targetArea = GenerationArea.transform;
		minPos = new Vector3(targetArea.position.x - targetArea.localScale.x / 2, targetArea.position.y - targetArea.localScale.y / 2, targetArea.position.z - targetArea.localScale.z / 2);
		maxPos = new Vector3(targetArea.position.x + targetArea.localScale.x / 2, targetArea.position.y + targetArea.localScale.y / 2, targetArea.position.z + targetArea.localScale.z / 2);

		NumOfObjects = Random.Range(MinNumOfObjects, MaxNumOfObjects);
		ArrObst = new GameObject[NumOfObjects];
		for (int i = 0; i < NumOfObjects; i++)
		{
			ArrObst[i] = Instantiate(ObstaclePrefab, new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), Random.Range(minPos.z, maxPos.z)), Quaternion.identity) as GameObject;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Equals("Player"))
		{
			ObjectOfDeactivation.GetComponent<Collider>().enabled = false;
			ObjectOfDeactivation.GetComponent<MeshRenderer>().enabled = false;
			Invoke("Destruction", 15f);
		}
	}

	private void Destruction()
	{
		foreach (var v in ArrObst)
			Destroy(v);
	}
}
