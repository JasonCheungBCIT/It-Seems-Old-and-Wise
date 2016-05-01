using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour, Growable {
	// Target is 3 units to go up

	public float progress = 0.0f; // 1.0f is completed 
	public float speed    = 0.01f;
	public float distance = 3.0f;

	private float incrementDistance;	// Distance 'grown' for each grow() 

	// Use this for initialization
	void Start () {
		incrementDistance = distance / (1.0f / speed); 
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Growable.Grow() {
		// Check if completed
		if (progress >= 1.0f)
			return;

		// Grow 
		progress += speed;
		transform.Translate (transform.up * incrementDistance, Space.World);
	}
}
