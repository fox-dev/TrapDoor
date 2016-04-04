using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	LineRenderer line;
	int layerMask;
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

		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = true;

		layerMask = 1 << 8;

		layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void Update () 
	{

		line.material.mainTextureOffset = new Vector2 (Time.time, 0);

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		line.SetPosition (0, ray.origin);
		if (Physics.Raycast (ray, out hit, 100, layerMask)) {
			line.SetPosition (1, hit.point);
			if (hit.collider.tag == "Player") {
				print ("I hit the player");

				if (hit.collider.gameObject.GetComponent<PlayerMovement> ().getSuperSpeed () || hit.collider.gameObject.GetComponent<PlayerMovement>().invulnerable())
                {
				}
                else if(!hit.collider.gameObject.GetComponent<PlayerMovement>().isDead())
                {
                    hit.collider.gameObject.GetComponent<PlayerMovement>().blink();
					gameController.resetScoreMultiplier();
				}
                /*else
                {
                    hit.collider.gameObject.GetComponent<PlayerMovement>().setGameOver();
                }*/
			}
		}
		else
			line.SetPosition (1, ray.GetPoint (100));
	}
}
