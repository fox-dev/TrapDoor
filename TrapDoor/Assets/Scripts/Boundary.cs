using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    private RotateManager rotateTracker;

    public bool willRotate;


    // Use this for initialization
    void Start () {

        willRotate = false;

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
        if(other.tag == "Junction")
        {
            willRotate = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Set" && willRotate == true) //Setting new rotations.
        {
            if (rotateTracker.getOrientation() == "down") //down orientation to left or right
            {
                other.gameObject.SetActive(false);
                if (rotateTracker.getTurn() == "left") 
                {
                    other.transform.rotation = Quaternion.Euler(0, 270, 0);
                    other.transform.position = new Vector3(other.transform.position.x - 33f, other.transform.position.y, other.transform.position.z + 155f);
                    willRotate = false;
                }
                else if (rotateTracker.getTurn() == "right") 
                {
                    other.transform.rotation = Quaternion.Euler(0, 90, 0);
                    other.transform.position = new Vector3(other.transform.position.x + 33f, other.transform.position.y, other.transform.position.z + 155f);
                    willRotate = false;
                }
                else if (rotateTracker.getOrientation() == "down")
                {
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 178f);
                }
                else
                {
                    willRotate = false;
                }
      
            }

            else if (rotateTracker.getOrientation() == "left") //left orientation to up or down
            {
                other.gameObject.SetActive(false);

                if (rotateTracker.getTurn() == "up") 
                {
                    other.transform.rotation = Quaternion.Euler(0, 180, 0);
                    other.transform.position = new Vector3(other.transform.position.x - 155f, other.transform.position.y, other.transform.position.z - 33f);
                    willRotate = false;
                }

                else if (rotateTracker.getTurn() == "down")
                {
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                    other.transform.position = new Vector3(other.transform.position.x - 155f, other.transform.position.y, other.transform.position.z + 33f);
                    willRotate = false;
                }
                else if (rotateTracker.getOrientation() == "left")
                {
                    other.transform.position = new Vector3(other.transform.position.x - 178f, other.transform.position.y, other.transform.position.z);
                }
                else
                {
                    willRotate = false;
                }
            }

            else if (rotateTracker.getOrientation() == "right") //left orientation to up or down
            {
                other.gameObject.SetActive(false);

                if (rotateTracker.getTurn() == "up")
                {
                    other.transform.rotation = Quaternion.Euler(0, 180, 0);
                    other.transform.position = new Vector3(other.transform.position.x + 155f, other.transform.position.y, other.transform.position.z - 33f);
                    willRotate = false;
                }

                else if (rotateTracker.getTurn() == "down")
                {
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                    other.transform.position = new Vector3(other.transform.position.x + 155f, other.transform.position.y, other.transform.position.z + 33f);
                    willRotate = false;
                }
                else if (rotateTracker.getOrientation() == "right")
                {
                    other.transform.position = new Vector3(other.transform.position.x + 178f, other.transform.position.y, other.transform.position.z);
                }
                else
                {
                    willRotate = false;
                }
            }

            else if (rotateTracker.getOrientation() == "up") //up orientation to left or right
            {
                other.gameObject.SetActive(false);

                if (rotateTracker.getTurn() == "left")
                {
                    other.transform.rotation = Quaternion.Euler(0, 270, 0);
                    other.transform.position = new Vector3(other.transform.position.x - 33f, other.transform.position.y, other.transform.position.z - 155f);
                    willRotate = false;
                }
                else if (rotateTracker.getTurn() == "right")
                {
                    other.transform.rotation = Quaternion.Euler(0, 90, 0);
                    other.transform.position = new Vector3(other.transform.position.x + 33f, other.transform.position.y, other.transform.position.z - 155f);
                    willRotate = false;
                }
                else if (rotateTracker.getOrientation() == "up")
                {
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 178f);
                }
                else
                {
                    willRotate = false;
                }
            }
            other.gameObject.SetActive(true);
        }
        else //for normal use and no junction is entered
        {
            if (other.tag == "Set")
            {
                other.gameObject.SetActive(false);
                if (rotateTracker.getOrientation() == "down")
                {
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 155);
                }
                else if (rotateTracker.getOrientation() == "left")
                {
                    other.transform.position = new Vector3(other.transform.position.x - 155f, other.transform.position.y, other.transform.position.z);
                }

                else if (rotateTracker.getOrientation() == "right")
                {
                    other.transform.position = new Vector3(other.transform.position.x + 155f, other.transform.position.y, other.transform.position.z);
                }
                else if (rotateTracker.getOrientation() == "up")
                {
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 155f);
                }


                other.gameObject.SetActive(true);
            }
        }
      
    }


}
