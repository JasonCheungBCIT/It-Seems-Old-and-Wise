using UnityEngine;
using System.Collections;

public class AggroTrigger : MonoBehaviour {

	// ...
	public Knight knight;

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.CompareTag("Player")) {
			knight.isAggro = true;
			this.gameObject.SetActive (false);
		}
	}
}
