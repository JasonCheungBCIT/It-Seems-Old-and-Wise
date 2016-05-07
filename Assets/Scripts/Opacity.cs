using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Opacity : MonoBehaviour {

	public float opacityLevel = 0.1f;

	// Use this for initialization
	void Start () {
		foreach (Image child in GetComponentsInChildren<Image>()) {	// This includes self 
			child.color = new Color(1f, 1f, 1f, opacityLevel);
		}
		foreach (SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>()) {	// This includes self 
			child.color = new Color(1f, 1f, 1f, opacityLevel);
		}
	}

}
