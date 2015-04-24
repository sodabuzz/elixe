using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController Instance;

	public GameObject camera;
	public float lifeLevel = 100.0f;
	public float flighSpeed = 1.0f;
	public float maxAltitude = 1.0f;
	public float cameraMoveAlt = 0.7f;
	public float maxXOffset = 0.5f;

	private Vector3 cameraUp, cameraDown;

	public bool standing = true;
	
	private Animator animator;
	private float initialGameSpeed;

	private ObstacleController obstacleController;
	
	void Start () {
		animator = GetComponent<Animator> ();
		initialGameSpeed = 5;
		Instance = this;
	}
	
	void FixedUpdate () {

		float velocityX = GameController.Instance.moving.x;
		float velocityY = GameController.Instance.moving.y;

		// In the air

		if (GameController.Instance.moving.x > 0) {
			if (transform.position.x < maxXOffset){
				transform.Translate(Vector3.right * flighSpeed * Time.deltaTime * velocityX/4);
				standing = false;
			}
		}
		if (GameController.Instance.moving.x < 0) {
			if (transform.position.x > -maxXOffset){
				transform.Translate(Vector3.left * flighSpeed * Time.deltaTime * -velocityX/4);
				standing = false;
			}
		}

		if (GameController.Instance.moving.y > 0) {
			if (transform.position.y < maxAltitude){
				transform.Translate(Vector3.up * flighSpeed * Time.deltaTime * velocityY);
				standing = false;
				//Camera.main.transform.Translate((Vector3.up * flighSpeed * Time.deltaTime * velocityY)/2);
				if (transform.position.y > cameraMoveAlt) {
					//Camera.main.transform.Translate(Vector3.up * flighSpeed * Time.deltaTime);
					//Camera.main.transform.Translate(Vector3.up * flighSpeed * Time.deltaTime * velocityY);
					//cameraUp = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 0.1, Camera.main.transform.position.z);
					//Camera.main.transform.Translate(cameraUp);
				}
			}
		}

		if (GameController.Instance.moving.y < 0) {
			if (transform.position.y > 0.01){
				transform.Translate(Vector3.down * flighSpeed * Time.deltaTime * -velocityY);
				standing = false;
				//Camera.main.transform.Translate((Vector3.down * flighSpeed * Time.deltaTime * -GameController.Instance.moving.y)/2);
				if (transform.position.y > cameraMoveAlt) {
					//Camera.main.transform.Translate(Vector3.down * flighSpeed * Time.deltaTime);
					//Camera.main.transform.Translate(Vector3.down * flighSpeed * Time.deltaTime * -velocityY);
					//cameraDown = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 0.1, Camera.main.transform.position.z);
					//Camera.main.transform.Translate(cameraDown);

				}
			}
		}

		// On the ground

		if (transform.position.y < 0.01f) {
			transform.position = new Vector3 (transform.position.x,transform.position.y,0);
			standing = true;
		}

		if (standing) {
			animator.SetInteger("animState", 0);
			GameController.Instance.gameSpeed = initialGameSpeed;
		}
		else {
			animator.SetInteger("animState", 1);
			GameController.Instance.gameSpeed = initialGameSpeed * 2;
		}
	}
	
	void Update () {
		// Check if dead
		if (lifeLevel <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {

		obstacleController = other.gameObject.GetComponent<ObstacleController> ();

		switch (other.tag)
		{	
			case "Obstacle":
			lifeLevel -= obstacleController.hitDamage;
			Debug.Log("Life: " + lifeLevel);
			camera.SendMessage("DoShake",0.15,SendMessageOptions.DontRequireReceiver);
			break;
		}

		//Debug.Log("Hit " + other.tag);
	}

	void OnGUI()
	{
		//GUILayout.Label ("LIFE: " + lifeLevel);	
	}
}
