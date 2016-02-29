﻿using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Vector3 endPos;
    Vector3 startPos;
    public float speed;
	private GameController gameController;

    private RotateManager rotateTracker;

    bool red,blue,green;

	// Use this for initialization
	void Start () {
        
        startPos = transform.localPosition;
		if (tag == "RedRight") {
			endPos = new Vector3 (startPos.x + 10f, startPos.y, startPos.z);
		} else if (tag == "BlueRight") {
			endPos = new Vector3 (startPos.x + 10f, startPos.y, startPos.z);
		} else if (tag == "GreenRight") {
			endPos = new Vector3 (startPos.x + 10f, startPos.y, startPos.z);
		} else if (tag == "RedLeft") {
			endPos = new Vector3 (startPos.x - 10f, startPos.y, startPos.z);
		} else if (tag == "BlueLeft") {
			endPos = new Vector3 (startPos.x - 10f, startPos.y, startPos.z);
		} else if (tag == "GreenLeft") {
			endPos = new Vector3 (startPos.x - 10f, startPos.y, startPos.z);
		} else if (tag == "LaserDoorRed" || tag == "LaserDoorBlue" || tag == "LaserDoorGreen") {
			endPos = new Vector3 (startPos.x, startPos.y + 10f, startPos.z);	
		}
        
		red = false;
        blue = false;
        green = false;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}


        GameObject rotateTrackerObject = GameObject.FindWithTag("Rotator");
        if (rotateTrackerObject != null)
        {
            rotateTracker = rotateTrackerObject.GetComponent<RotateManager>();
        }
        if (rotateTracker == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        GetComponent<Collider>().isTrigger = true;
    }

    void Reset()
    {
        

    }

    void OnDisable()
    {

       
    }


  

	
	// Update is called once per frame
	void Update () 
	{
		gameController.getColorStates (ref red, ref green, ref blue);
       
        if (Input.GetKeyDown("r") && !red)
        {
            red = true;
            blue = false;
            green = false;
         
        }
        else if (Input.GetKeyDown("r") && red)
        {
            red = false;
         
        }

        if (Input.GetKeyDown("b") && !blue)
        {
            blue = true;
            red = false;
            green = false;
          
        }
        else if (Input.GetKeyDown("b") && blue)
        {
            blue = false;
         
        }

        if (Input.GetKeyDown("g") && !green)
        {
            green = true;
            red = false;
            blue = false;
        
        }
        else if (Input.GetKeyDown("g") && green)
        {
            green = false;
          
        }



    }
		
    void FixedUpdate()
    {
        //No color restrictions on.
        /* 
        if (tag == "Red" && red)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
        }
        else if(tag == "Red" && !red)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }

        if (tag == "Blue" && blue)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
        }
        else if(tag == "Blue" && !blue)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        */

        RighttDoorClose();
        LeftDoorClose();
		LaserDoorClose();

    }

    void RighttDoorClose()
    {
        //With color restrictions on
        if (tag == "RedRight" && red) //red is on
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
        }
        //close all other colors
        else if (red == true && (tag == "BlueRight" || tag == "GreenRight"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "RedRight" && !red)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }

        else if (tag == "BlueRight" && blue) //blue is on
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
        }
        //close all other colors
        else if (blue == true && (tag == "RedRight" || tag == "GreenRight"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "BlueRight" && !blue)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "GreenRight" && green) //green is on
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);

        }
        //close all other colors
        else if (green == true && (tag == "RedRight" || tag == "BlueRight"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "GreenRight" && !green)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
    }

    void LeftDoorClose()
    {
        //With color restrictions on
        if (tag == "RedLeft" && red) //red is on
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
        }
        //close all other colors
        else if (red == true && (tag == "BlueLeft" || tag == "GreenLeft"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "RedLeft" && !red)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }

        else if (tag == "BlueLeft" && blue) //blue is on
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
        }
        //close all other colors
        else if (blue == true && (tag == "RedLeft" || tag == "GreenLeft"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "BlueLeft" && !blue)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "GreenLeft" && green) //green is on
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);

        }
        //close all other colors
        else if (green == true && (tag == "RedLeft" || tag == "BlueLeft"))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "GreenLeft" && !green)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
    }

	void LaserDoorClose()
	{
		//With color restrictions on
		if (tag == "LaserDoorRed" && red) //red is on
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
		}
		//close all other colors
		else if (red == true && (tag == "LaserDoorBlue" || tag == "LaserDoorGreen"))
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
		}
		else if (tag == "LaserDoorRed" && !red)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
		}

		else if (tag == "LaserDoorBlue" && blue) //blue is on
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);
		}
		//close all other colors
		else if (blue == true && (tag == "LaserDoorRed" || tag == "LaserDoorGreen"))
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
		}
		else if (tag == "LaserDoorBlue" && !blue)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
		}
		else if (tag == "LaserDoorGreen" && green) //green is on
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed * Time.deltaTime);

		}
		//close all other colors
		else if (green == true && (tag == "LaserDoorRed" || tag == "LaserDoorBlue"))
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
		}
		else if (tag == "LaserDoorGreen" && !green)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
		}		
	}
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("PLAYER 1!!!!!");
            if (other.gameObject.GetComponent<PlayerMovement>().getSuperSpeed() == true)
            {
               
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("PLAYER 2!!!!!");
            if (other.gameObject.GetComponent<PlayerMovement>().getSuperSpeed() == true)
            {
               
                    other.GetComponent<Rigidbody>().drag = 40;

            }
            else
            {
                
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody>().drag = 0;
        }
    }
}
