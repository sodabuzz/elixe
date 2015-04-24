using UnityEngine;
using System.Collections;

public class basic_AI : MonoBehaviour {
	public float HP=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			
			if (HP <= 0) {
				
				
			Destroy (gameObject);
				
				
			}
	
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Obstacle")
		{
		}
		else  {
			
			HP--;
		}
	}
}
