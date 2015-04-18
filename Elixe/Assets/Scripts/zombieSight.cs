using UnityEngine;
using System.Collections;

public class zombieSight : MonoBehaviour {

	public Transform sightStart, sightEnd;

	void Update () {
		GetComponent<Collider2D>().enabled = false;
		//RaycastHit2D hit = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Wall"));
		RaycastHit2D hit = Physics2D.Linecast(sightStart.position, sightEnd.position);
		GetComponent<Collider2D>().enabled = true;
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

		if (hit.collider != null)
			transform.localScale = new Vector3 ((transform.localScale.x == 1) ? -1 : 1, 1, 1);

	}
}
