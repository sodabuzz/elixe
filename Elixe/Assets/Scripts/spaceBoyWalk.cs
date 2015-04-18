using UnityEngine;
using System.Collections;


public class spaceBoyWalk : MonoBehaviour {

	public float speed = 10;
	public Vector2 maxVelocity = new Vector2(3,5);

	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;

	private Animator animator;
	private playerControler controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<playerControler> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		var absVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);

		// Check if on the ground or in the air
		if (absVelY < 0.2f) {
			standing = true;
		}
		else {
			standing = false;
		}

		Debug.Log(controller.moving.x);

		// If the character is moving
		if (controller.moving.x != 0) {
			if(absVelX < maxVelocity.x){
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
			}
			if (standing) {
				if (controller.moving.x == 1) {
					animator.SetInteger("animState", 1);
				}
				else {
					animator.SetInteger("animState", 2);
				}
			} 
			else {
				if (controller.moving.y > 0) {
					if (absVelY < maxVelocity.y){
						forceY = jetSpeed * controller.moving.y;
					}
					animator.SetInteger("animState", 3);
				}
				else {
					animator.SetInteger("animState", 0);
				}
			}
		}
		else {
			animator.SetInteger("animState", 0);
		}

		if (controller.moving.y > 0) {
			if (absVelY < maxVelocity.y){
				forceY = jetSpeed * controller.moving.y;
			}
			animator.SetInteger("animState", 3);
		}

		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY));
	
	}
}