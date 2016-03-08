using UnityEngine;
using System.Collections;

public class BoostGaugeTrigger : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
	
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {

			if (other.gameObject.GetComponent<PlayerMovement> ().getSuperSpeed ()) {
			
			} else if (this.tag == "LaserPiece") {

				print ("NO BOOST FOR YOU");
				
			} else {
				gameController.addBoost (10);
			}
	
            gameController.addScore(10);
		}
	}		
}
