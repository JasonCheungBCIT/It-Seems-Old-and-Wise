using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Knight : MonoBehaviour, Growable {

	// Knight
	public Transform Hero;
	public float speed = 10f; 
	public bool isAggro = false;

	// Rust 
	public float progress = 0.0f; // 1.0f is completed 
	public float growthSpeed = 0.02f;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (isAggro) {

			Rigidbody2D rb = GetComponent<Rigidbody2D> ();

			if (transform.position.x - Hero.position.x > 0) {		// Hero is to the left of the knight
				rb.velocity = new Vector2 (-speed, rb.velocity.y);	// Move knight towards player
				if (facingRight)									// Orient sprite correctly is need be
					Flip ();
			} else { 
				rb.velocity = new Vector2 (speed, rb.velocity.y);
				if (!facingRight)
					Flip ();
			}
		}

	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1. (reverse sprite)
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (isAggro) {
			if (c.gameObject.tag == "Player") {
				// game over 
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}

	void Growable.Grow() {
		// Check if completed
		if (progress >= 1.0f) {
			isAggro = false;
			// GetComponent<Collider2D> ().enabled = false; falls through the world
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);	// Freeze knight
			GetComponent<SpriteRenderer>().color = new Color(183 / 255f, 65/255f, 14/255f, 1);
			// transform.gameObject.SetActive (false);
			Debug.Log ("metal complete");
			return;
		}

		// Grow 
		isAggro = true;
		progress += growthSpeed;
		TintColor ();
	}

	private Color TintColor() {
		float r, g, b; // percentage r g b
		// Note: (Base - difference * progress %) / to percentage 
		// Alt: 1f - progress - (183f * progress / 255f) 
		r = (255 - (255 - 183) * progress) / 255;
		g = (255 - (255 - 65) * progress) / 255;
		b = (255 - (255 - 14) * progress) / 255;
		Debug.Log ("r " + r + " g " + g + " b " + b);
		GetComponent<SpriteRenderer> ().color = new Color (r, g, b, 1);
		return new Color (r, g, b, 1);
	}
}
