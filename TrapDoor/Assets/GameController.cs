using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool red;
	public bool green;
	public bool blue;

	// Use this for initialization
	void Start () {

		red = false;
		green = false;
		blue = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RedPress()
	{
		if (red) {
			red = false;
		} else {
			red = true;
		}
		blue = false;
		green = false;
	}

	public void GreenPress()
	{
		if (green) {
			green = false;
		} else {
			green = true;
		}
		blue = false;
		red = false;
	}

	public void BluePress()
	{
		if (blue) {
			blue = false;
		} else {
			blue = true;
		}
		red = false;
		green = false;
	}

	public void getColorStates(ref bool r,ref bool g,ref bool b)
	{
		r = red;
		g = green;
		b = blue;
	}

}
