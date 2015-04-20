using UnityEngine;
using System.Collections;

public class backgroundParallax : MonoBehaviour {

	private GameObject player;
	private Vector3 moveBackground = new Vector3(0,0,0);
	private Rigidbody2D playerRigidbody2D;

	public float parralaxRatio = 300.0f;

	void Start () {
		player = GameObject.FindWithTag("Player");
		playerRigidbody2D = player.GetComponent<Rigidbody2D>();
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(playerRigidbody2D.velocity.x);
		moveBackground  = new Vector3(-playerRigidbody2D.velocity.x / parralaxRatio, -playerRigidbody2D.velocity.y / parralaxRatio, 0);
		gameObject.transform.Translate(moveBackground);
	}
}
