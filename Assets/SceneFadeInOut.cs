using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
	public Image FadeImg;
	public float fadeSpeed = 1.2f;
	public bool sceneStarting = true;

	void Awake()
	{
		FadeImg = GetComponent<Image> ();
		FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
		SceneStart ();
	}

	void Update()
	{
		/*
		// If the scene is starting...
		if (sceneStarting)
			// ... call the StartScene function.
			StartScene();
	*/}

	public void SceneStart() {
		StartCoroutine (FadeToClear ());
	}

	private IEnumerator FadeToClear() {
		while (FadeImg.color.a > 0) {
			FadeImg.color = new Color(0, 0, 0, FadeImg.color.a - Time.deltaTime * fadeSpeed);
			yield return null;
		}
		Debug.Log ("Fade to clear finished");
		FadeImg.enabled = false;
	}

	public void SceneEnd(string nextScene) {
		StartCoroutine (FadeToBlack (nextScene));
	}

	private IEnumerator FadeToBlack(string nextScene) {
		FadeImg.enabled = true;
		while (FadeImg.color.a < 1.0f) {
			FadeImg.color = new Color(0, 0, 0, FadeImg.color.a + Time.deltaTime * fadeSpeed); 
			Debug.Log (FadeImg.color.a);
			yield return null;
		}
		Debug.Log ("Fade to black finished");
		SceneManager.LoadScene (nextScene);
	}


	/*
	void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
	}


	void StartScene()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if (FadeImg.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the RawImage.
			FadeImg.color = Color.clear;
			FadeImg.enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}
	}


	public void EndScene(string sceneName)
	{
		// Make sure the RawImage is enabled.
		FadeImg.enabled = true;

		// Start fading towards black.
		FadeToBlack();

		// If the screen is almost black...
		if (FadeImg.color.a >= 0.95f)
			// ... load the level
			SceneManager.LoadScene(sceneName);
	}*/
}