using UnityEngine;
using System.Collections;

public class LightShaderScript : MonoBehaviour {

	public float fadeSpeed = 2f;
	public float highIntensity = 1f;
	public float lowIntensity = 1.03f;
	public float changeMargin = 0.002f;

	public Renderer rend;

	private float targetIntensity, scaleX;

	// Use this for initialization
	void Start () 
	{
		scaleX = lowIntensity;
		rend.material.mainTextureScale = new Vector2(scaleX, 1f);
	}

	// Update is called once per frame
	void Update () 
	{
		scaleX = Mathf.Lerp (scaleX, targetIntensity, fadeSpeed * Time.deltaTime);
		rend.material.mainTextureScale = new Vector2(scaleX, 1f);
		CheckTargetIntensity ();
	}

	void CheckTargetIntensity()
	{	
		if (Mathf.Abs (targetIntensity - scaleX) < changeMargin) {
			if (targetIntensity == highIntensity) {
				targetIntensity = lowIntensity;
			} else {
				targetIntensity = highIntensity;
			}
		}
	}
}
