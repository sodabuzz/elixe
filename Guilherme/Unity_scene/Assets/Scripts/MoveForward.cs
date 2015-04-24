using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public Vector3 direction = Vector3.forward;
	
	// Update is called once per frame
	void Update () {
	
		transform.position += transform.rotation * -(direction * GameController.Instance.gameSpeed * Time.deltaTime);

	}
}
