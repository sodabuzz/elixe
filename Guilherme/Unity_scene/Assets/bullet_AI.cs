using UnityEngine;
using System.Collections;

public class bullet_AI : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter ()
{
	Destroy(gameObject);
}
}
