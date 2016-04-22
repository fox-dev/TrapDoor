using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rotation : MonoBehaviour {
 
    public GameObject player;
    public GameObject playerModel;
    public GameObject boundary;

    public bool completed;

    public string rotateTo;

    private RotateManager rotateTracker;

    public bool slowDown;

    public bool entered;

    public Button leftButton, rightButton, downButton;
    public Transform leftButtonPos, rightButtonPos, downButtonPos;
    private Vector3 startPosLeft, startPosRight, startPosDown;



    // Use this for initialization
    void Start () {

        startPosLeft = leftButton.transform.position;
        startPosRight = rightButton.transform.position;
        startPosDown = downButton.transform.position;


        completed = false;

        slowDown = true;

        entered = false;

		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f;

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

    void OnEnable()
    {

        slowDown = true;
        completed = false;


        GameObject rotateTrackerObject = GameObject.FindWithTag("Rotator");
        if (rotateTrackerObject != null)
        {
            rotateTracker = rotateTrackerObject.GetComponent<RotateManager>();
        }
        if (rotateTracker == null)
        {
            Debug.Log("Cannot find 'RotateManager' script");
        }

        if(rotateTracker.getOrientation() == "down")
        {
            leftButton.onClick.AddListener(() => rightButtonStuff());
            rightButton.onClick.AddListener(() => leftButtonStuff());
            downButton.onClick.AddListener(() => downButtonStuff());
        }
        else if (rotateTracker.getOrientation() == "up")
        {
            leftButton.onClick.AddListener(() => leftButtonStuff());
            rightButton.onClick.AddListener(() => rightButtonStuff());
            downButton.onClick.AddListener(() => upButtonStuff());
        }
        else if (rotateTracker.getOrientation() == "left")
        {
            leftButton.onClick.AddListener(() => downButtonStuff());
            rightButton.onClick.AddListener(() => upButtonStuff());
            downButton.onClick.AddListener(() => leftButtonStuff());
        }
        else if (rotateTracker.getOrientation() == "right")
        {
            leftButton.onClick.AddListener(() => upButtonStuff());
            rightButton.onClick.AddListener(() => downButtonStuff());
            downButton.onClick.AddListener(() => rightButtonStuff());
        }
        

        

        



    }
	
	// Update is called once per frame
	void FixedUpdate () {


        

        if (entered && slowDown)
        {
            leftButton.transform.position = Vector3.Lerp(leftButton.transform.position, leftButtonPos.transform.position, 0.1f);
            rightButton.transform.position = Vector3.Lerp(rightButton.transform.position, rightButtonPos.transform.position, 0.1f);
            downButton.transform.position = Vector3.Lerp(downButton.transform.position, downButtonPos.transform.position, 0.1f);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                completed = true;
                entered = false;
                slowDown = false;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
                rotateTo = "up";
                print("UP");
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                completed = true;
                entered = false;
                slowDown = false;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
                rotateTo = "down";
                print("DOWN");

            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                completed = true;
                entered = false;
                slowDown = false;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
                rotateTo = "right";
                print("RIGHT");
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                completed = true;
                entered = false;
                slowDown = false;
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
                rotateTo = "left";
                print("LEFT");
            }
        }
        else
        {
            leftButton.transform.position = Vector3.Lerp(leftButton.transform.position, startPosLeft, 0.05f);
            rightButton.transform.position = Vector3.Lerp(rightButton.transform.position, startPosRight, 0.05f);
            downButton.transform.position = Vector3.Lerp(downButton.transform.position, startPosDown, 0.05f);
        }

        
       

    }


    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !completed)
        {
            entered = true;

            if (slowDown)
            {
                Time.timeScale = 0.5f;
                Time.fixedDeltaTime = 0.5f * 0.02f;
            }
            else
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
            }

            

            


        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            completed = true;
            entered = false;
            slowDown = true;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            print("SETTING ORIENTATION TO: " + rotateTo);
            rotateTracker.setRotation(rotateTo);
            if (rotateTo == rotateTracker.getOrientation())
            {

            }
            else
            {
                //other.GetComponent<Rigidbody>().velocity = Vector3.zero;s
                //other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }



            
        }

    }

    public void leftButtonStuff()
    {
        
        slowDown = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        rotateTo = "left";
        print("LEFT");
    }
    public void rightButtonStuff()
    {
        
        slowDown = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        rotateTo = "right";
        print("RIGHT");
    }
    public void upButtonStuff()
    {
        
        slowDown = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        rotateTo = "up";
        print("UP");
    }
    public void downButtonStuff()
    {
        
        slowDown = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        rotateTo = "down";
        print("DOWN");
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
