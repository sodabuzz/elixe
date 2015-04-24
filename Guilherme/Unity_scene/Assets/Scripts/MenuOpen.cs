using UnityEngine;
using System.Collections;

public class MenuOpen : MonoBehaviour {

	public GameObject pauseButton, pausePanel;

	// Use this for initialization
	void Start () {
		OnResume();
	}

	public void OnPause() {
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		pauseButton.SetActive(false);
	}

	public void OnResume() {
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		pauseButton.SetActive(true);
	}
}
