using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	private Text scoreText;
	private Text lifeText;

	// Use this for initialization
	void Start () {
		//scoreText = gameObject.GetComponent("Score") as Text;
		//Debug.Log(scoreText);
	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = ((int)GameController.Instance.score).ToString ();
	}
}
