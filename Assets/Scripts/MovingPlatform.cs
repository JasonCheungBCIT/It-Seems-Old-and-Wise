using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour, Growable {

	public float speed = 1f;
	public Collider2D leftBound;
	public Collider2D rightBound;
	public bool isHorizontal = true;	// Move horizontally, or vertically

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other == leftBound || other == rightBound) {
			speed *= -1;
		} 
	}
		
	void Growable.Grow() {
		transform.Translate (transform.right * speed); // double the speed
	}
}
