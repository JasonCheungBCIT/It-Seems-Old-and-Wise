using UnityEngine;
using System.Collections;

public class TimeDistortionArea : MonoBehaviour {

	public float moveSpeed = 0.5f;

	private int timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = PlayerPrefs.GetInt (GameInfo.TIME_LEFT);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = Vector2.Lerp (transform.position, target, moveSpeed);	// Gradually move the object to the target pos. 
	
		if (Input.GetMouseButtonDown(0)) {
			GetComponent<Animator> ().SetBool ("mouseDown", true); 
		} else if (Input.GetMouseButtonUp (0)) {
			GetComponent<Animator> ().SetBool ("mouseDown", false); 
		}


	}

	void OnTriggerStay2D(Collider2D other) {

		if (Input.GetMouseButton(0) && other.GetComponent<Growable>() != null) {	// left-button held 
			other.GetComponent<Growable>().Grow();
			Debug.Log(other);
			Debug.Log ("Clicked in other colliders"); 
		}
	}
}
