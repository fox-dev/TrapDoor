using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Vector3 endPos;
    Vector3 startPos;
    public float speed;

    bool red,blue,green;

	// Use this for initialization
	void Start () {
        print("Start: " + transform.position.z);
        startPos = transform.position;
        if (tag == "Red")
        {
            endPos = new Vector3(startPos.x + 10f, startPos.y, startPos.z);
        }
        else if(tag == "Blue")
        {
            endPos = new Vector3(startPos.x - 10f, startPos.y, startPos.z);
        }
        else if (tag == "Green")
        {
            endPos = new Vector3(startPos.x + 10f, startPos.y, startPos.z);
        }
        else
        {
            print("never");
        }
        red = true;
        blue = false;
        green = false;

        print("End: " + endPos.z);


    }

    void Awake()
    {

    }

	
	// Update is called once per frame
	void Update () {

        
       

        if (Input.GetKeyDown("r") && !red)
        {
            red = true;
            blue = false;
            green = false;
            print("Red is true");
        }
        else if (Input.GetKeyDown("r") && red)
        {
            red = false;
            print("Red is false");
        }

        if (Input.GetKeyDown("b") && !blue)
        {
            blue = true;
            red = false;
            green = false;
            print("Blue is true");
        }
        else if (Input.GetKeyDown("b") && blue)
        {
            blue = false;
            print("Blue is false");
        }

        if (Input.GetKeyDown("g") && !green)
        {
            green = true;
            red = false;
            blue = false;
            print("Blue is true");
        }
        else if (Input.GetKeyDown("g") && green)
        {
            green = false;
            print("Blue is false");
        }



    }

    void FixedUpdate()
    {
        //No color restrictions on.
        /* 
        if (tag == "Red" && red)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if(tag == "Red" && !red)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

        if (tag == "Blue" && blue)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else if(tag == "Blue" && !blue)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
        */

        //With color restrictions on
        if (tag == "Red" && red) //red is on
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        //close all other colors
        else if (red == true && (tag == "Blue" || tag == "Green"))
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
        else if(tag == "Red" && !red)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

        else if (tag == "Blue" && blue) //blue is on
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        //close all other colors
        else if (blue == true && (tag == "Red" || tag == "Green"))
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
        else if (tag == "Blue" && !blue)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }


        else if (tag == "Green" && green) //green is on
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        }
        //close all other colors
        else if (green == true && (tag == "Red" || tag == "Blue"))
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
        else if (tag == "Blue" && !blue)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
        else if (tag == "Green" && !green)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }





    }
}
