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
		
		splash.CrossFadeAlpha (255, 0.5f, false);
		yield return new WaitForSeconds (.75f);
		splash.CrossFadeAlpha (0.0f, 0.25f, false);
		yield return new WaitForSeconds (.25f);
		SceneManager.LoadScene("Menu");
		yield return null;

	}
}
