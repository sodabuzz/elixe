using UnityEngine;
using System.Collections;

public class MoveLeftRight : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Input.GetAxis("Horizontal") * GameController.Instance.gameSpeed * Time.deltaTime * -1;
	}
}
