using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	// Movement variables
	private float moveX = 0.0f;
	private float moveY = 0.0f;

	// To control speed on the floor
	public float speed = 10;
	public Vector2 maxVelocity = new Vector2(3,5);

	// To control speed in the air
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;
	
	// To check if on the floor or in the air
	public bool isGrounded;
	public Transform groundCheck;
	public LayerMask groundLayers;
	public float groundCheckRadius = 2f;

	// Components used
	private Animator animator;
	private Rigidbody2D rigidbody2D;
	
	void Start () {
		// Get components
		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");

		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs(rigidbody2D.velocity.y);
		var absVelY = Mathf.Abs(rigidbody2D.velocity.y);

		// Check if on the ground
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers); 

		// If the character is moving left or right
		if (moveX != 0) {

			// Set different forceX if on the ground or in the air
			if(absVelX < maxVelocity.x){
				forceX = isGrounded ? speed * moveX : (speed * moveX * airSpeedMultiplier);
			}

			// If on the ground
			if (isGrounded) {
				if (moveX > 0 && moveY == 0) {
					animator.SetInteger("animState", 1);
					Debug.Log("1");
				}
				else if (moveX < 0 && moveY == 0){
					animator.SetInteger("animState", 2);
					Debug.Log("2");
				}
				else if (moveX > 0 && moveY > 0) {
					animator.SetInteger("animState", 3);
					Debug.Log("3");
				}
				else if (moveX < 0 && moveY > 0) {
					animator.SetInteger("animState", 4);
					Debug.Log("4");
				}
			} // If in the air
			else {
				// If rising up
				if (moveY > 0) {
					if (absVelY < maxVelocity.y){
						forceY = jetSpeed * moveY;
					}
					if (moveX > 0) {
						animator.SetInteger("animState", 3);
						Debug.Log("up 3");
					}
					if (moveX < 0) {
						animator.SetInteger("animState", 4);
						Debug.Log("up 4");
					}

				} // If falling
				else {
					animator.SetInteger("animState", 0);
				}
			}
		}
		else {
			animator.SetInteger("animState", 0);
		}

		
		// If using the jetpack
		if (moveY > 0) {
			if (absVelY < maxVelocity.y){
				forceY = jetSpeed * moveY;
			}
			animator.SetInteger("animState", 3);
		}

		// Do the thing
		rigidbody2D.AddForce (new Vector2 (forceX, forceY));
	
	}
}