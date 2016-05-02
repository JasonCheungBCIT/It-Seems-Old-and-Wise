using UnityEngine;
using System.Collections;

public class MeetFamilyTrigger : MonoBehaviour {

	public Transform wife, child, hero;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.CompareTag ("Player")) {
			StartCoroutine (PlayAnimation());
		}
	}

	public IEnumerator PlayAnimation()
	{
		hero.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);	// pause for reunion 
		yield return new WaitForSeconds(2f);

		hero.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0);	// hero continue
		yield return new WaitForSeconds(3f);

		wife.localScale = new Vector3 (-1f, 1f, 1f);						// turn wife around
		child.localScale = new Vector3 (-1f, 1f, 1f);						// turn child around
		wife.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0);	// follow hero
		child.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0);	// follow hero

	}
}
