using UnityEngine;
using System.Collections;

public class DestroyGameObject : MonoBehaviour {

	public float destroyXValue = 50f;
	public float destroyZValue = -40f;
	public float destroyZEndValue = 50f;

	// Update is called once per frame
	void Update () {
		
		if (transform.position.z <= destroyZValue || transform.position.z > destroyZEndValue || transform.position.x >= destroyXValue || transform.position.x <= -destroyXValue) {
			Destroy (gameObject);
		}

	}

}
