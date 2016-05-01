using UnityEngine;
using System.Collections;

// Used to reset player data and start the game off.
public class Initializer : MonoBehaviour {

	public int refill = -1;

	// Use this for initialization
	void Start () {
		if (refill == -1)
			PlayerPrefs.SetInt (GameInfo.TIME_LEFT, GameInfo.MAX_TIME);
		else
			PlayerPrefs.SetInt (GameInfo.TIME_LEFT, refill);
		Debug.Log (PlayerPrefs.GetInt (GameInfo.TIME_LEFT));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
