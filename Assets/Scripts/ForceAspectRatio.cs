using UnityEngine;
using System.Collections;

public class ForceAspectRatio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float currentAspecRatio = (float)Screen.width / (float)Screen.height;
		float targetAspectRatio = 4.0f / 3.0f; // eg. 1024 / 768 

		if (currentAspecRatio > targetAspectRatio)	// Aspect ratio is too wide, bound by height.
			Screen.SetResolution (
				(int)(Screen.height * targetAspectRatio), 
				(int)Screen.height, 
				Screen.fullScreen
			);
		else 										// Aspect ratio is too long, bound by width.
			Screen.SetResolution (
				(int)Screen.width, 
				(int)(Screen.width / targetAspectRatio), 
				Screen.fullScreen
			);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
