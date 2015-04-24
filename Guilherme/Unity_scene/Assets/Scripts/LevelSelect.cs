using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public int focus = 1;

	// Use this for initialization
	void Start () {
		level1.transform.localScale = new Vector3(3F, 3F, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("right")) {
			if (focus == 3){
				focus = 1;
			}
			else focus += 1;
		}
		if (Input.GetKeyUp("left")) {
			if (focus == 1){
				focus = 3;
			}
			else focus -= 1;
		}

		if (focus == 1){
			level1.transform.localScale = new Vector3(3F, 3F, 0);
			level2.transform.localScale = new Vector3(2, 2, 2);
			level3.transform.localScale = new Vector3(2, 2, 2);
		}
		if (focus == 2){
			level2.transform.localScale = new Vector3(3F, 3F, 0);
			level1.transform.localScale = new Vector3(2, 2, 2);
			level3.transform.localScale = new Vector3(2, 2, 2);
		}
		if (focus == 3){
			level3.transform.localScale = new Vector3(3F, 3F, 0);
			level2.transform.localScale = new Vector3(2, 2, 2);
			level1.transform.localScale = new Vector3(2, 2, 2);
		}

		if (Input.GetKeyUp("space")) {
			if (focus == 1){
				Application.LoadLevel("félix playground");
			}
			if (focus == 2){
				Application.LoadLevel("test grotte");
			}
			if (focus == 3){
				Application.LoadLevel("Lucas Mer");
			}
		}

	}
}
