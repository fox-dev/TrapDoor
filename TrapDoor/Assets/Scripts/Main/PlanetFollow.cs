using UnityEngine;
using System.Collections;

public class PlanetFollow : MonoBehaviour {

    public GameObject player;

    private RotateManager rotateTracker;

    // Use this for initialization
    void Start () {

        GameObject rotateTrackerObject = GameObject.FindWithTag("Rotator");
        if (rotateTrackerObject != null)
        {
            rotateTracker = rotateTrackerObject.GetComponent<RotateManager>();
        }
        if (rotateTracker == null)
        {
            Debug.Log("Cannot find 'RotateManager' script");
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

   public void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlanetCam")
        {
            print("leaving");
            if(rotateTracker.getOrientation() == "down")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 1300);
            }
            else if(rotateTracker.getOrientation() == "up")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 1300);
            }
            else if (rotateTracker.getOrientation() == "left")
            {
                transform.position = new Vector3(transform.position.x - 2800, transform.position.y, transform.position.z);
            }
            else if (rotateTracker.getOrientation() == "right")
            {
                transform.position = new Vector3(transform.position.x + 2800, transform.position.y, transform.position.z);
            }
            




        }


            
    }
}
