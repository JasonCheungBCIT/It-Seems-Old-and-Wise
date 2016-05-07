using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiController : MonoBehaviour {

	public Image timeDisplay; // sand in the hour glass. Call parent to get the entire gameobject. 
	public Image iconAccel, iconDoubleJump, iconDash;

	[HideInInspector]
	public bool timeEnabled = true;
	[HideInInspector]
	public bool accelEnabled = true;
	[HideInInspector]
	public bool jumpEnabled = true;
	[HideInInspector]
	public bool dashEnabled = true;

	private float initialTimeHeight = 60;

	// Use this for initialization
	void Start () {

		updateIconsEnabled ();

		// Update the hourglass display
		initialTimeHeight = timeDisplay.rectTransform.rect.height;
		int remainingTime = PlayerPrefs.GetInt (GameInfo.TIME_LEFT);
		// float percentageLeft = GameInfo.MAX_TIME / remainingTime;
		// updateTimeDisplay (0.50f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateIconsEnabled() {
		timeDisplay.transform.parent.gameObject.SetActive (timeEnabled);
		iconAccel.gameObject.SetActive (accelEnabled);
		iconDoubleJump.gameObject.SetActive (jumpEnabled);
		iconDash.gameObject.SetActive(dashEnabled);
	}

	public void updateTimeDisplay(float percentage) {
		Debug.Log ("updateTimeDisplay: " + initialTimeHeight * percentage);
		Rect currentBounds = timeDisplay.rectTransform.rect; 
		timeDisplay.rectTransform.sizeDelta = new Vector2 (currentBounds.width, initialTimeHeight * percentage);
	}

}
