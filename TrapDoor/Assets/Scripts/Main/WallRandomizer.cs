using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallRandomizer : MonoBehaviour 
{

	public List<GameObject> walls;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Randomization script: On activation, picks one wall to be inactive and sets others to active.
	void OnEnable()
	{
		int opening = Random.Range (0, walls.Count);
		for(int i = 0; i < walls.Count; i++)
		{
			if (i == opening) {
				walls [i].SetActive (false);
			} else {
				walls [i].SetActive (true);
			}
		}
	}
}
