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

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {

			if (other.gameObject.GetComponent<PlayerMovement> ().getSuperSpeed () || other.gameObject.GetComponent<PlayerMovement>().invulnerable()) {
			
			} else if (this.tag == "LaserPiece") {

				print ("NO BOOST FOR YOU");
				
			} else {
				gameController.incrementBoost();
			}


            if (!other.GetComponent<PlayerMovement>().invulnerable())
            {
                gameController.addScore(10 * gameController.getMultiplier());
                gameController.incDoorCounter();
            }
            else
            {
                gameController.resetScoreMultiplier();
            }
            
		}
	}		
}
