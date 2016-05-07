using UnityEngine;
using System.Collections;

public class PrologueHeroAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (PlayAnimation());
		// PlayAnimation ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator PlayAnimation()
	{
		yield return new WaitForSeconds(2f);
		transform.localScale = new Vector3 (1f, 1f, 1f);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (1, 0);
		//yield return new WaitForSeconds(5f);
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
	}

}
