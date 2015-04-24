using UnityEngine;
using System.Collections;

public class Wasp_manager : MonoBehaviour {
	public float HP=100;
	private Animator anim;
	public Transform smallHornet;
	public bool poppedyet=false;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (HP <= 0) {


			if (poppedyet==false) {
			anim.SetInteger ("state", 1);
		
			
				poppedyet=true;
			}
	
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





	void Die () {
	

		
		Destroy(gameObject);

	}

	void pop () {

		Instantiate(smallHornet,transform.position+new Vector3(0, 0.25F, 0), Quaternion.identity) ;
		Instantiate(smallHornet,transform.position+new Vector3(-0.25F, 0.5f, 0), Quaternion.identity) ;
		Instantiate(smallHornet,transform.position+new Vector3(0.25F, 0.5f, 0), Quaternion.identity) ;
		Instantiate(smallHornet,transform.position+new Vector3(0, 0.75F, 0), Quaternion.identity) ;
}
}