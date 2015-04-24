using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	
	public static GameController Instance;
	public float gameSpeed = 1.0f;
	
	public Vector2 moving = new Vector2();
	
	private GameObject player;
	public float score = 0.0f;
	public float pointPerUnit = 1.0f;
	private Text scoreText;
	private Text lifeText;
	
	private GameObject scoreObj;
	private GameObject lifeObj;
	private GameObject gameoverObj;
	
	public bool gameOver = false;
	
	private GameObject hero;
	private PlayerController playerController;
	
	void Start () {
		Instance = this;
		hero = GameObject.Find ("Hero");
		scoreObj = GameObject.Find ("Score");
		lifeObj = GameObject.Find ("Life");
		gameoverObj = GameObject.Find ("GameOver");
		
		scoreText = scoreObj.GetComponent<Text> ();
		lifeText = lifeObj.GetComponent<Text> ();

		gameoverObj.SetActive(false);
	}
	
	
	void Update () {
		
		// Keys control
		moving.x = moving.y = 0;
		Debug.Log(Input.GetAxis ("Horizontal"));

		moving.x = Input.GetAxis ("Horizontal");
		moving.y = Input.GetAxis ("Vertical");

//		if (Input.GetAxis ("Horizontal") > 0){
//			moving.x = 1;
//		}
//		if (Input.GetAxis ("Horizontal") < 0){
//			moving.x = -1; 
//		}
//
//		if (Input.GetAxis ("Vertical") > 0){
//			moving.y = 1;
//		}
//		if (Input.GetAxis ("Vertical") < 0){
//			moving.y = -1;
//		}

//		if (Input.GetKey ("right")){
//			Debug.Log("right");
//			moving.x = 1;
//		} else if (Input.GetKey ("left")){
//			Debug.Log("left");
//			moving.x = -1;
//		}
//		
//		if (Input.GetKey ("up")){
//			Debug.Log("up");
//			moving.y = 1;
//		} else if (Input.GetKey ("down")){
//			Debug.Log("down");
//			moving.y = -1;
//		}
		
		// Game Over management - WRONG: The player should send the gameover message when he dies
		if(GameObject.Find ("Hero") == null) {
			gameOver = true;
			gameoverObj.SetActive(true);
		}
		
		if (gameOver) {
			
			if (Input.anyKeyDown)
			{
				Application.LoadLevel(Application.loadedLevel);
				gameoverObj.SetActive(false);
			}
		}
	}

	void FixedUpdate () {

			if (!gameOver) {
			score += pointPerUnit * gameSpeed * Time.deltaTime;
			scoreText.text = ((int)GameController.Instance.score).ToString ();
			lifeText.text = PlayerController.Instance.lifeLevel.ToString ();
		}
	}
	void Points (float pts){
		score = score + pts;
	}

}
















