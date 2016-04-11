using UnityEngine;
using System.Collections;

public class LaserWall : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () 
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.GetComponent<PlayerMovement>().blink();
			gameController.laserWallDecrement ();
			gameController.resetScoreMultiplier ();
			other.GetComponent<Rigidbody>().drag = 15;
			other.GetComponent<PlayerMovement>().setMoveSpeed(gameController.getPlayer().GetComponent<PlayerMovement>().getMoveSpeed());

		}


	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			other.GetComponent<Rigidbody>().drag = 0;
		}
	}
}
