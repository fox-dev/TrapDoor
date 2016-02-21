using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	LineRenderer line;
	int layerMask;

	// Use this for initialization
	void Start () 
	{
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = true;

		layerMask = 1 << 8;

		layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void Update () 
	{

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		line.SetPosition (0, ray.origin);
		if (Physics.Raycast (ray, out hit, 100, layerMask)) {
			line.SetPosition (1, hit.point);
			if (hit.collider.tag == "Player") {
				print ("I hit the player");
			}
		}
		else
			line.SetPosition (1, ray.GetPoint (100));
	}
}
