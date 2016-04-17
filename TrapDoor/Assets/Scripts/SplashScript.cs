using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour {

	//Splash screen references
	public RawImage splash;

	// Use this for initialization
	void Start () {
		startFade ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// splashFade
	/// Fades in and out the splash screen and starts music.
	/// </summary>
	/// <returns>The fade.</returns>

	public void startFade()
	{
		StartCoroutine ("SplashFade");
	}

	IEnumerator SplashFade()
	{

		splash.CrossFadeAlpha (255, 1.5f, false);
		yield return new WaitForSeconds (1.5f);
		splash.CrossFadeAlpha (0.0f, 1.0f, false);
		yield return new WaitForSeconds (1.0f);

		SceneManager.LoadScene ("Menu");

		yield return null;

	}
}
