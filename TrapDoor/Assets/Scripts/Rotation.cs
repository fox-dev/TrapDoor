using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
 
    public GameObject player;
    public GameObject playerModel;
    public GameObject boundary;

    public string rotateTo;

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


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rotateTracker.setTurn(rotateTo);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            rotateTracker.setRotation(rotateTo);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }


    }

}
