using UnityEngine;
using System.Collections;

// Attaches a game object to a moving platform
public class AttachableToPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "MovingPlatform") {
			Debug.Log (this + " attaching to " + c.gameObject);
			transform.parent = c.transform;
		}
	}

	void OnCollisionExit2D(Collision2D c) {
		if (c.gameObject.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

}
