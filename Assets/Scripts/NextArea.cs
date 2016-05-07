using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextArea : MonoBehaviour {

	public string nextLevel = "Level1";
	public SceneFadeInOut helper;

	void Start() {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			helper.SceneEnd (nextLevel);
			gameObject.SetActive (false);
			// SceneManager.LoadScene (nextLevel);
		}
	}
		
}
