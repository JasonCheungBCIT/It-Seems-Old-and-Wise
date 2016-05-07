using UnityEngine;
using System.Collections;

public class ReachHouseTrigger : MonoBehaviour {

	public Transform wife, child, hero;
	public SceneFadeInOut fader;

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
		wife.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);	// stop before hero
		child.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);	// stop before hero
		yield return new WaitForSeconds(1f);								// short pause (hero keeps walking)

		hero.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);	// stop before house 
		yield return new WaitForSeconds(1f);								// short pause

		hero.localScale = new Vector3 (1f, 1f, 1f);							// look at family
		yield return new WaitForSeconds(4f);

		fader.fadeSpeed = 0.8f;
		fader.SceneEnd ("_Menu");
	}
}
