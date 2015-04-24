using UnityEngine;
using System.Collections;

public class TargetRayCasting : MonoBehaviour {

	public Transform targetStart, targetEnd;
	public bool spotted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//sightStart = gameObject.transform.position;
		//sightEnd = gameObject.transform.position;
		Debug.Log(targetStart.position);
		Debug.Log(targetEnd.position);

		RaycastHit hit;

		Debug.DrawLine(targetStart.position, targetEnd.position, Color.green);
		spotted = Physics.Raycast(targetStart.position, targetEnd.position, out hit);

		if (spotted) {
			Debug.Log("Spotted:" + hit.point);
			Vector3 hitPoint = hit.point;
			gameObject.transform.Translate(new Vector3(hitPoint.x, hitPoint.y, hitPoint.z - 1));
		}

		Debug.Log(hit.point);
		//Gizmos.DrawLine(targetStart.position, targetEnd.position, Color.yellow);

		//Raycasting();
	}

	void Raycasting(){
		Debug.DrawLine(targetStart.position, targetEnd.position, Color.green);
	}
}
