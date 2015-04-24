using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {

	public GameObject spawnedObject;
	public GameObject spawnedObjectReverse;

	public float minHorizontal = -10f;
	public float maxHorizontal = 10f;
	public float minVertical = -10f;
	public float maxVertical = 10f;

	public float minSpawnInterval = 0.1f;
	public float maxSpawnInterval = 1.0f;
	public float retournement;
	public float minAngle;
	public float maxAngle;
	public float angle;
	//public float retournementRotation;
	//private GameObject clonePrefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnGameObject", Random.Range (minSpawnInterval, maxSpawnInterval), Random.Range (minSpawnInterval, maxSpawnInterval));
	}
	
	// Update is called once per frame
	void spawnGameObject () {

		retournement = Random.Range(0,10);
		angle = Random.Range (minAngle, maxAngle);
		if (retournement < 5 && spawnedObjectReverse != null ){
			Instantiate (spawnedObjectReverse, transform.position + new Vector3(Random.Range (minHorizontal, maxHorizontal),Random.Range (minVertical, maxVertical)),   Quaternion.Euler(0, 0, Random.Range(minAngle,maxAngle)));
		}
			
			else {
			Instantiate (spawnedObject, transform.position + new Vector3(Random.Range (minHorizontal, maxHorizontal),Random.Range (minVertical, maxVertical)), Quaternion.Euler(0, 0, Random.Range(minAngle,maxAngle)));
		}

		//Instantiate (spawnedObject, transform.position + new Vector3(Random.Range (minHorizontal, maxHorizontal),Random.Range (minVertical, maxVertical)), Quaternion.identity);
		//clonePrefab = spawnedObject;
		//clonePrefab.transform.localScale = Vector3(-1,1,1);
		//spawnedObject.transform.rotation.eulerAngles = Vector3(0, 180, 0);
		//Invoke ("spawnGameObject", Random.Range (maxSpawnInterval, maxSpawnInterval));
	}
}
