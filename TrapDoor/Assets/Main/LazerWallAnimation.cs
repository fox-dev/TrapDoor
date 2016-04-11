using UnityEngine;
using System.Collections;

public class LazerWallAnimation : MonoBehaviour {

	Renderer wall;

	// Use this for initialization
	void Start () {
	
		wall = gameObject.GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		wall.material.mainTextureOffset = new Vector2 (Time.time, 0);
	
	}
}
