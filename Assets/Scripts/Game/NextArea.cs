using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextArea : MonoBehaviour {

	public string nextLevel = "Level1";

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			SceneManager.LoadScene (nextLevel);
		}
	}
		
}
