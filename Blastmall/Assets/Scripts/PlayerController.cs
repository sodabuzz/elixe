using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	// Movement variables
	private float moveX = 0.0f;
	private float moveY = 0.0f;
	private float forceX = 0.0f;
	private float forceY = 0.0f;
	public float moveThreshold = 0.0f;
	private bool wasMovingX = false;
	private bool wasMovingY = false;

	// To control speed on the floor
	public float speed = 10.0f;
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
	
	void FixedUpdate () {
	
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");
		Debug.Log (moveX);

		forceX = 0f;
		forceY = 0f;

		var absVelX = Mathf.Abs(rigidbody2D.velocity.y);
		var absVelY = Mathf.Abs(rigidbody2D.velocity.y);

		// If the character is moving in diagonal
		if (moveX != 0.0f && moveY != 0.0f) {
			if (wasMovingX) {
				if (moveX > moveThreshold && moveY > moveThreshold)
				{
					animator.SetInteger("animState", 4);
					Debug.Log("1");
				}
				else if (moveX < -moveThreshold && moveY > moveThreshold)
				{
					animator.SetInteger("animState", 4);
					Debug.Log("2");
				}
				else if (moveX < -moveThreshold && moveY < -moveThreshold)	
				{
					animator.SetInteger("animState", 3);
					Debug.Log("4");
				}
				else if (moveX > moveThreshold && moveY < -moveThreshold)
				{
					animator.SetInteger("animState", 3);
					Debug.Log("3");
				}
				wasMovingX = false;
			}
			if (wasMovingY) {
				if (moveX > moveThreshold && moveY > moveThreshold)
				{
					animator.SetInteger("animState", 1);
					Debug.Log("1");
				}
				else if (moveX < -moveThreshold && moveY > moveThreshold)
				{
					animator.SetInteger("animState", 2);
					Debug.Log("2");
				}
				else if (moveX < -moveThreshold && moveY < -moveThreshold)	
				{
					animator.SetInteger("animState", 2);
					Debug.Log("4");
				}
				else if (moveX > moveThreshold && moveY < -moveThreshold)
				{
					animator.SetInteger("animState", 1);
					Debug.Log("3");
				}
				wasMovingY = false;
			}
		}
		else if (moveX != 0.0f || moveY != 0.0f) {
			if (moveX > 0)
			{
				animator.SetInteger("animState", 1);
				Debug.Log("1");
			}
			else if (moveX < -moveThreshold)
			{
				animator.SetInteger("animState", 2);
				Debug.Log("2");
			}
			if (moveY > moveThreshold)
			{
				animator.SetInteger("animState", 4);
				Debug.Log("4");
			}
			else if (moveY < -moveThreshold)
			{
				animator.SetInteger("animState", 3);
				Debug.Log("3");
			}

			// Keep track of last direction moved
			if (moveX != 0.0f) {
				wasMovingX = true;
			}
			else {
				wasMovingX = false;
			}
			if (moveY != 0.0f) {
				wasMovingY = true;
			}
			else {
				wasMovingY = false;
			}

		}
		else {
			animator.SetInteger("animState", 0);
			Debug.Log("0");
		}

		// Do the thing
		rigidbody2D.AddForce (new Vector2 (moveX*speed, moveY*speed));
	}

	// For debugging purpose
	void OnGUI()
	{
		GUILayout.Label ("moveX: " + moveX);
		GUILayout.Label ("moveY: " + moveY);
		GUILayout.Label ("forceX: " + forceX);
		GUILayout.Label ("forceY: " + forceY);
		GUILayout.Label ("animState: " + animator.GetInteger("animState"));
	}
	
}