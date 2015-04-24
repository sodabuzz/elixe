using UnityEngine;
using System.Collections;

public class SuivrePosition : MonoBehaviour {

	public GameObject player;

	public bool suivreX;
	public bool suivreY;
	public bool suivreZ;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {

		transform.position = new Vector3(0, 0, 0);

		if (suivreX == true){
			gameObject.transform.position.x = player.transform.position.x;
		}

		if (suivreY == true){
			gameObject.transform.position.y = player.transform.position.y;
		}

		if (suivreZ == true){
			gameObject.transform.position.z = player.transform.position.z;
		}
	}*/
}
