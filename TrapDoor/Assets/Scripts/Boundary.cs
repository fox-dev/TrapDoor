using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

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
            Debug.Log("Cannot find 'GameController' script");
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Set")
        {
            other.gameObject.SetActive(false);
            if(rotateTracker.getOrientation() == "down")
            {
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 200f);
            }
            else if(rotateTracker.getOrientation() == "left")
            {
                other.transform.position = new Vector3(other.transform.position.x - 200f, other.transform.position.y, other.transform.position.z);
            }

            else if (rotateTracker.getOrientation() == "right")
            {
                other.transform.position = new Vector3(other.transform.position.x + 200f, other.transform.position.y, other.transform.position.z);
            }
            else if (rotateTracker.getOrientation() == "up")
            {
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 200f);
            }


            other.gameObject.SetActive(true);
        }
      
    }


}
