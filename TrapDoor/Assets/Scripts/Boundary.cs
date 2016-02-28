using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boundary : MonoBehaviour {

    public List<GameObject> activePieces;

    public string rotateTo;

    public string orientation; 

    public List<GameObject> inactivePieces;

    private RotateManager rotateTracker;

    public GameObject lastPiece;
    public GameObject toPlace;

    public GameObject player;


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

        setRandomRotation();

    }
	
	// Update is called once per frame
	void Update () {
        orientation = rotateTracker.getOrientation();

        print("Current rot:" + rotateTracker.getOrientation());

        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Set")//for normal use and no junction is entered
        {
            print("Placing set");

            toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
            inactivePieces.Remove(toPlace);

            if (rotateTracker.getOrientation() == "down")
            {
                
                if(toPlace.tag != "Junction")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 154);
                   
                }
                else
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 165);
                }

            }
            else if (rotateTracker.getOrientation() == "left")
            {
                

                if (toPlace.tag != "Junction")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x - 154, other.transform.position.y, other.transform.position.z);
                }
                else
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x - 165, other.transform.position.y, other.transform.position.z);
                }

            }

            else if (rotateTracker.getOrientation() == "right")
            {
                
                if (toPlace.tag != "Junction")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x + 154f, other.transform.position.y, other.transform.position.z);
                }
                else
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x + 165f, other.transform.position.y, other.transform.position.z);
                }

            }
            else if (rotateTracker.getOrientation() == "up")
            {
                
                if (toPlace.tag != "Junction")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 154f);
                }
                else
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 165f);
                }

            }

            toPlace.gameObject.SetActive(true); //enable piece
        }
        else if(other.tag == "Junction")
        {
            print("Placing junction");
            other.GetComponent<Rotation>().setRotateTo(rotateTo);
            bool found = false;
            while (found == false) //get set piece that is not another junction
            {
                toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                if (toPlace.tag == "Junction")
                {
                    found = false;
                }
                else
                {
                    found = true;
                }
            }
            inactivePieces.Remove(toPlace);

            if (rotateTracker.getOrientation() == "down") //down orientation to left or right
            {

                if (rotateTo == "left")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x - 33, other.transform.position.y, other.transform.position.z );


                }
                else if (rotateTo == "right")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x + 33, other.transform.position.y, other.transform.position.z );


                }
                else if (rotateTo == "down")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 33);

                }
                else
                {

                }

            }
            else if (rotateTracker.getOrientation() == "left") //left orientation to up or down
            {


                if (rotateTo == "up")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x , other.transform.position.y, other.transform.position.z - 33);

                }

                else if (rotateTo == "down")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x , other.transform.position.y, other.transform.position.z + 33);

                }
                else if (rotateTo == "left")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x - 33, other.transform.position.y, other.transform.position.z);

                }
                else
                {

                }
            }   

            else if (rotateTracker.getOrientation() == "right") //left orientation to up or down
            {


                if (rotateTo == "up")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x , other.transform.position.y, other.transform.position.z - 33);

                }

                else if (rotateTo == "down")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x , other.transform.position.y, other.transform.position.z + 33);

                }
                else if (rotateTo == "right")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x + 33, other.transform.position.y, other.transform.position.z);

                }
                else
                {

                }
            }

            else if (rotateTracker.getOrientation() == "up") //up orientation to left or right
            {


                if (rotateTo == "left")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x - 33, other.transform.position.y, other.transform.position.z);

                }
                else if (rotateTo == "right")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x + 33, other.transform.position.y, other.transform.position.z);

                }
                else if (rotateTo == "up")
                {
                    toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
                    toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 33);

                }
                else
                {

                }
            }
            toPlace.gameObject.SetActive(true);
            

        }

    }



    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Set")
        {

            other.gameObject.SetActive(false);


            inactivePieces.Add(other.gameObject);
        }

        if (other.tag == "Junction")
        {
            // other.gameObject.SetActive(false);

            inactivePieces.Add(other.gameObject);

            setRandomRotation();

        }
    }

    public void setRandomRotation()
    {

        bool found = false;
        while (found == false)
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
                rotateTo = "left";
            }
            else if (num == 3)
            {
                rotateTo = "right";
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


}
