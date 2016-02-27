using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameObject playerModel, boundary;

    private RotateManager rotateTracker;

    public float moveSpeed;

    private Vector3 currentAngle, targetAngle;

    private float lastXPos, lastYPos, lastZPos;

    Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        currentAngle = transform.eulerAngles;

        GameObject rotateTrackerObject = GameObject.FindWithTag("Rotator");
        if (rotateTrackerObject != null)
        {
            rotateTracker = rotateTrackerObject.GetComponent<RotateManager>();
        }
        if (rotateTracker == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        lastXPos = 0f; //starting pos;

        lastZPos = -32.7f; //starting pos;

     


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        

       // print(rotateTracker.getOrientation());

        if (rotateTracker.getOrientation() == "down")
        {
            //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            targetAngle = new Vector3(0, 0, 0);

            currentAngle = new Vector3(
               Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5));

            playerModel.transform.eulerAngles = currentAngle;

            boundary.transform.rotation = Quaternion.Euler(0, 180f, 0);

            Vector3 temp = new Vector3(0, 0, 30);
            GetComponent<Rigidbody>().AddRelativeForce(temp);

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, moveSpeed);

            Vector3 keyPos = new Vector3(lastXPos, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, keyPos, 0.5f);

            lastZPos = transform.position.z; //keep last Z pos in case of rotation;

        }

        else if (rotateTracker.getOrientation() == "left")
        {
            targetAngle = new Vector3(0, 270f, 0);

            currentAngle = new Vector3(
               Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5));

            playerModel.transform.eulerAngles = currentAngle;

            boundary.transform.rotation = Quaternion.Euler(0, 270, 0);

            Vector3 temp = new Vector3(-30, 0, 0);
            GetComponent<Rigidbody>().AddRelativeForce(temp);

            GetComponent<Rigidbody>().velocity = new Vector3(-moveSpeed, 0, 0);

            Vector3 keyPos = new Vector3(transform.position.x, transform.position.y, lastZPos);
            transform.position = Vector3.Lerp(transform.position, keyPos, 0.5f);

            lastXPos = transform.position.x;
        }

        else if (rotateTracker.getOrientation() == "right")
        {

            targetAngle = new Vector3(0, 90f, 0);

            currentAngle = new Vector3(
               Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5));

            playerModel.transform.eulerAngles = currentAngle;

            boundary.transform.rotation = Quaternion.Euler(0, 90, 0);

            Vector3 temp = new Vector3(30, 0, 0);
            GetComponent<Rigidbody>().AddRelativeForce(temp);

            GetComponent<Rigidbody>().velocity = new Vector3(moveSpeed, 0, 0);

            Vector3 keyPos = new Vector3(transform.position.x, transform.position.y, lastZPos);
            transform.position = Vector3.Lerp(transform.position, keyPos, 0.5f);

            lastXPos = transform.position.x;
        }

        else if (rotateTracker.getOrientation() == "up")
        {
            //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);

            targetAngle = new Vector3(0, 180f, 0);

            currentAngle = new Vector3(
               Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 5),
               Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5));

            playerModel.transform.eulerAngles = currentAngle;

            boundary.transform.rotation = Quaternion.Euler(0, 180f, 0);

            Vector3 temp = new Vector3(0, 0, -30);
            GetComponent<Rigidbody>().AddRelativeForce(temp);

            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -moveSpeed);

            Vector3 keyPos = new Vector3(lastXPos, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, keyPos, 0.5f);

            lastZPos = transform.position.z; //keep last Z pos in case of rotation;

        }



        //print(Input.GetAxis("Horizontal"));

        //input movement
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

        //Automove
        // Vector3 movement = new Vector3(0.0f, 0.0f, 1f);
        //GetComponent<Rigidbody>().velocity = movement * moveSpeed;
        

        if (rb.velocity.magnitude > moveSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }



    }
}
