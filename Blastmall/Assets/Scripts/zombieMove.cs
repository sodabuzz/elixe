using UnityEngine;
using System.Collections;

public class zombieMove : MonoBehaviour {

	public float speed = 0.5f;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0) * speed;
	}
}
