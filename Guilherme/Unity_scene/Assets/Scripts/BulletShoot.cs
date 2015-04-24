using UnityEngine;
using System.Collections;

public class BulletShoot : MonoBehaviour {

	public GameObject bullet;
	public float loadingTime = 2.0f;
	public float rate = 1.0f;
	private float rateCount = 0.0f;
	public float load =0.0f;
	private Animator anim;
	public GameObject arme;
	public float overheattime = 6.0f ;
	public bool isoverheating= false;
	//public GameObject camera;

	void Start () {
		anim = arme.GetComponent<Animator> ();
		//camera = GameObject.Find("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {


			load = load + 0.01f;

			if (load < loadingTime&& isoverheating == false) {
				anim.SetInteger ("state", 1);
			}
			if (load >= loadingTime && load < overheattime) {
				rateCount++;
				anim.SetInteger ("state", 2);
				if (rateCount == rate) {
					Instantiate (bullet, transform.position, Quaternion.identity);
					rateCount = 0.0f;
					//camera.SendMessage("DoShake",0.01,SendMessageOptions.DontRequireReceiver);
				}
			}
			if (load >= overheattime) {
				anim.SetInteger ("state", 3);

				OverHeat();
			}

		}
		else {
			load=0;
			anim.SetInteger("state", 0);

	}
}
	IEnumerator OverHeat () {

		isoverheating = true;
		yield return new WaitForSeconds(3);
		load=0;
		isoverheating= false;
	}

}

