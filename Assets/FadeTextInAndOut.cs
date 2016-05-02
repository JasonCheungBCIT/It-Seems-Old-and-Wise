using UnityEngine;
using System.Collections;

public class FadeTextInAndOut : MonoBehaviour {

	Animator _animator;

	// Use this for initialization
	void Start () {
		// Animator animation = GetComponent<Animator> ();
		_animator = GetComponent<Animator> (); 
		PlayOneShot ("AnimStart");
		/*
		animation["FadeTextInAndOut"].wrapMode = WrapMode.Once;
		animation.Play("FadeTextInAndOut");
*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator PlayOneShot ( string paramName )
	{
		_animator.SetBool( paramName, true );
		yield return null;
		_animator.SetBool( paramName, false );
	}
}
