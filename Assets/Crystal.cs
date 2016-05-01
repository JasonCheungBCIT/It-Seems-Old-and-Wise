using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {

	public GameObject nextArea;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.CompareTag ("Player")) {
			nextArea.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
