using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform hero;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
		transform.position =  new Vector3 (transform.position.x, (1+hero.position.y)/1.3f , transform.position.z);
	}
}
