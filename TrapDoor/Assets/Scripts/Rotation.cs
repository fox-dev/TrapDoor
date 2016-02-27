using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
 
    public GameObject player;
    public GameObject playerModel;
    public GameObject boundary;

    public bool completed;

    public string rotateTo;

    private RotateManager rotateTracker;



    // Use this for initialization
    void Start () {

        completed = false;

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
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            print("SETTING ORIENTATION TO: " + rotateTo);
            rotateTracker.setRotation(rotateTo);
            if(rotateTo == rotateTracker.getOrientation())
            {
               
            }
            else
            {
                //other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            
            //this.gameObject.SetActive(false);
        }

    }

    public void setRandomRotation()
    {

        bool found = false;
        while(found == false)
        {
           int num = Random.Range(0, 3);
            if (num == 0)
            {
                rotateTo = "up";
            }
            else if (num == 1)
            {
                rotateTo = "down";
            }
            else if (num == 2)
            {
                rotateTo = "right";
            }
            else if (num == 3)
            {
                rotateTo = "left";
            }

            if (rotateTo == "up" && rotateTracker.getOrientation() == "down")
            {
                found = false;
            }
            else if (rotateTo == "down" && rotateTracker.getOrientation() == "up")
            {
                found = false;
            }
            else if (rotateTo == "left" && rotateTracker.getOrientation() == "right")
            {
                found = false;
            }
            else if (rotateTo == "right" && rotateTracker.getOrientation() == "left")
            {
                found = false;
            }
            else
            {
                found = true;
            }
        }
          
    }

    public void setRotateTo(string s)
    {
        rotateTo = s;
    }

    public void setCompleted()
    {

        completed = true;
    }


    public bool getCompleted()
    {
        return completed;
    }

    public string getRotateTo()
    {
        return rotateTo;
    }

}
