using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FallenOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "Player") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
