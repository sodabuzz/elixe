using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	public GameObject coinParticule;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player");
		{
			Instantiate (coinParticule, transform.position, Quaternion.identity);
			Destroy(this);
			gameManager.SendMessage ( "Points", 50.0f ) ;
		}
	}
}
