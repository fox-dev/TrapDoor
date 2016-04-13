using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialWallRandomizer : MonoBehaviour {

	public List<GameObject> walls;

	public float wallTimer;
	public float timer;

	// Use this for initialization
	void Start () {

		timer = wallTimer;
		randomizeWalls ();
	}

	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0) {
			randomizeWalls ();
			timer = wallTimer;
		}
	}


	//Randomization script: On activation, picks one wall to be inactive and sets others to active.
	void randomizeWalls()
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

	void onEnable()
	{
		timer = wallTimer;
		randomizeWalls ();
	}
}
