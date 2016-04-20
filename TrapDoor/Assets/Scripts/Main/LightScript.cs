using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

	public float fadeSpeed = 2f;
	public float highIntensity = 2f;
	public float lowIntensity = 0.5f;
	public float changeMargin = 0.2f;

	public Light myLight;
	private float targetIntensity;

	public float highIntensityShader;
	public float lowIntensityShader;

	public Renderer rend;
	private float shaderTarget, scaleX;

	// Use this for initialization
	void Start () 
	{
		myLight.intensity = lowIntensity;

		scaleX = lowIntensityShader;
		rend.material.mainTextureScale = new Vector2(scaleX, 1f);

		shaderTarget = highIntensityShader;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myLight.intensity = Mathf.Lerp (myLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
		scaleX = Mathf.Lerp (scaleX, shaderTarget, fadeSpeed * Time.deltaTime);
		rend.material.mainTextureScale = new Vector2(scaleX, 1f);
		CheckTargetIntensity ();
	}

	void CheckTargetIntensity()
	{	
		if (Mathf.Abs (targetIntensity - myLight.intensity) < changeMargin) {
			if (targetIntensity == highIntensity) {
				targetIntensity = lowIntensity;
				shaderTarget = lowIntensityShader;
			} else {
				targetIntensity = highIntensity;
				shaderTarget = highIntensityShader;
			}
		}
	}

}
