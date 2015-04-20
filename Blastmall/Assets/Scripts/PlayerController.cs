using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	// Movement variables
	private float moveX = 0.0f;
	private float moveY = 0.0f;
	private float forceX = 0.0f;
	private float forceY = 0.0f;

	// To control speed on the floor
	public float speed = 10;
	public Vector2 maxVelocity = new Vector2(3,5);

	// To control speed in the air
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = 0.3f;
	
	// To check if on the floor or in the air
	public bool isGrounded = true;
	public Transform groundCheck;
	public LayerMask groundLayers;
	public float groundCheckRadius = 2f;

	public bool lookRight = true;

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
		//Debug.Log("MoveX:" + moveX);
		//Debug.Log("MoveY:" + moveY);

		forceX = 0f;
		forceY = 0f;

		var absVelX = Mathf.Abs(rigidbody2D.velocity.y);
		var absVelY = Mathf.Abs(rigidbody2D.velocity.y);


		// Check if on the ground
		//isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers); 

		// If the character is moving left or right
		if (moveX != 0.0f) {

			// Set a different forceX if on the ground or in the air
			if(absVelX < maxVelocity.x){
				forceX = isGrounded ? speed * moveX : (speed * moveX * airSpeedMultiplier);
			}

			// If on the ground
			// To Improve: Animation should start with movement < 1?
			if (isGrounded && moveY <= 0)
			{
				if (moveX > 0)
				{
					animator.SetInteger("animState", 1);
					Debug.Log("1");
				}
				else if (moveX < 0)
				{
					animator.SetInteger("animState", 2);
					Debug.Log("2");
				}
			} // If taking off while walking
			else if (isGrounded && moveY > 0) 
			{
				if (absVelY < maxVelocity.y){
					forceY = jetSpeed * moveY;
				}
				if (moveX > 0) 
				{
					animator.SetInteger("animState", 3);
					Debug.Log("wlk+up rg 3");
				} 
				else if (moveX < 0) 
				{
					animator.SetInteger("animState", 3);
					Debug.Log("wlk+up lf 3");
				}
			} // If in the air
			else if (!isGrounded)
			{
				// If rising up
				if (moveY > 0) {
					if (absVelY < maxVelocity.y){
						forceY = jetSpeed * moveY;
					}
					if (moveX > 0) {
						animator.SetInteger("animState", 5);
						Debug.Log("up 3");
					}
					if (moveX < 0) {
						animator.SetInteger("animState", 4);
						Debug.Log("up 4");
					}

				} // If falling left or right
				else {
					if (moveX > 0) {
						animator.SetInteger("animState", 6);
						Debug.Log("Falling right");
					}
					else if (moveX < 0) {
						animator.SetInteger("animState", 5);
						Debug.Log("Falling left");
					}
					else {
						Debug.Log("Falling");
					}
				}
			}
		}
		else {
			// If idle and taking off or turning jetpack on while falling
			if (moveY > 0) {
				if (absVelY < maxVelocity.y){
					forceY = jetSpeed * moveY;
				}
				animator.SetInteger("animState", 3);
				Debug.Log("idle 3");
			}
			if (moveY < 0) {
				if (absVelY < maxVelocity.y){
					forceY = jetSpeed * moveY;
				}
				animator.SetInteger("animState", 3);
				Debug.Log("idle 3");
			}
			else { // Idle position
				animator.SetInteger("animState", 0);
				Debug.Log("idle 0");
			}
		}

		// Do the thing
		//if (animator.GetInteger("animState") != 0 ){
			rigidbody2D.AddForce (new Vector2 (forceX, forceY));
		//}
	}

	// For debugging purpose
	void OnGUI()
	{
		GUILayout.Label ("moveX: " + moveX);
		GUILayout.Label ("moveY: " + moveY);
		GUILayout.Label ("forceX: " + forceX);
		GUILayout.Label ("forceY: " + forceY);
	}
	
}