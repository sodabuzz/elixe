using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		Vector2 speed = new Vector2(0,GameController.Instance.gameSpeed * Time.deltaTime);
		GetComponent<Renderer>().material.mainTextureOffset += speed;
		GetComponent<Renderer>().material.mainTextureOffset += Vector2.right * Input.GetAxis("Horizontal") * GameController.Instance.gameSpeed * Time.deltaTime;
	}
}
