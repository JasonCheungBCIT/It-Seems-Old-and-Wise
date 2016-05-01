using UnityEngine;
using System.Collections;

// Activates gravity for self and target
public class ActivateGravity : MonoBehaviour {

	public Rigidbody2D target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.CompareTag ("Player")) {
			GetComponent<Rigidbody2D> ().isKinematic = false;
			target.isKinematic = false;
		}
	}
}
