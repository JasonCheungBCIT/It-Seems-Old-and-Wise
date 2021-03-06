﻿using UnityEngine;
using System.Collections;

public class Metal : MonoBehaviour, Growable {
	// GRAY RGB 92 92 92
	// RUST RGB 183 65 14 
	public float progress = 0.0f; // 1.0f is completed 
	public float speed    = 0.02f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Growable.Grow() {
		// Check if completed
		if (progress >= 1.0f) {
			transform.gameObject.SetActive (false);
			Debug.Log ("metal complete");
			return;
		}
			
		// Grow 
		progress += speed;
		GetComponent<SpriteRenderer> ().color = TintColor();
	}

	private Color getColor() {
		float r, g, b; // percentage r g b 
		r = (92 + (183 - 92) * progress) / 255;	
		g = (92 + (65 - 92)  * progress) / 255;
		b = (92 + (14 - 93)  * progress) / 255;
		return new Color (r, g, b, 1);
	}

	private Color TintColor() {
		float r, g, b; // percentage r g b
		// Note: (Base - difference * progress %) / to percentage 
		// Alt: 1f - progress - (183f * progress / 255f) 
		r = (255 - (255 - 183) * progress) / 255;
		g = (255 - (255 - 65) * progress) / 255;
		b = (255 - (255 - 14) * progress) / 255;
		return new Color (r, g, b, 1);
	}
}
