using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Vector3 endPos;
    Vector3 startPos;
    public float speed;

    bool red,blue,green;

	// Use this for initialization
	void Start () {
        print("Start: " + transform.localPosition.z);
        startPos = transform.localPosition;
        if (tag == "RedRight")
        {
            endPos = new Vector3(startPos.x + 10f, startPos.y, startPos.z);
        }
        else if(tag == "BlueRight")
        {
            endPos = new Vector3(startPos.x + 10f, startPos.y, startPos.z);
        }
        else if (tag == "GreenRight")
        {
            endPos = new Vector3(startPos.x + 10f, startPos.y, startPos.z);
        }
        else if (tag == "RedLeft")
        {
            endPos = new Vector3(startPos.x - 10f, startPos.y, startPos.z);
        }
        else if (tag == "BlueLeft")
        {
            endPos = new Vector3(startPos.x - 10f, startPos.y, startPos.z);
        }
        else if (tag == "GreenLeft")
        {
            endPos = new Vector3(startPos.x - 10f, startPos.y, startPos.z);
        }

        red = false;
        blue = false;
        green = false;

        print("End: " + endPos.z);


    }

    void Reset()
    {
        

    }

    void OnDisable()
    {
     
 
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
        else if (tag == "BlueRight" && !blue)
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
        else if (tag == "BlueLeft" && !blue)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
        else if (tag == "GreenLeft" && !green)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed * Time.deltaTime);
        }
    }
}
