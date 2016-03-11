using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public GameObject playerModel, boundary;

    private GameController gameController;

    private RotateManager rotateTracker;

    public float moveSpeed, superMoveSpeed;

    private Vector3 currentAngle, targetAngle;

    public float lastXPos, lastYPos, lastZPos;

    Rigidbody rb;

    private bool superSpeed;

    public float lerpSpeed;

    public bool gameOver;



    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody>();

        currentAngle = transform.eulerAngles;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
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

        gameOver = false;

        lastXPos = 0f; //starting pos;

        lastZPos = -32.7f; //starting pos;



    }

    void Update()
    {
        //print(moveSpeed);
        if (Input.GetKeyDown("s"))
        {
            if (superSpeed)
            {
                superSpeed = false;
            }
            else
            {
                superSpeed = true;
            }

        }
        if (superSpeed) {
            gameController.decBoost(0.01f);
        }


    }

    // Update is called once per frame
    void FixedUpdate() {

        if (superSpeed && !gameOver)
        {
            
            if (rotateTracker.getOrientation() == "down")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, superMoveSpeed);
            }
            else if (rotateTracker.getOrientation() == "up")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -superMoveSpeed);
            }
            else if (rotateTracker.getOrientation() == "left")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-superMoveSpeed, 0, 0);
            }
            else if (rotateTracker.getOrientation() == "right")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(superMoveSpeed, 0, 0);
            }
        }
        else if(!gameOver)
        {
            
            if (rotateTracker.getOrientation() == "down")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, moveSpeed);
            }
            else if (rotateTracker.getOrientation() == "up")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -moveSpeed);
            }
            else if (rotateTracker.getOrientation() == "left")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-moveSpeed, 0, 0);
            }
            else if (rotateTracker.getOrientation() == "right")
            {
                GetComponent<Rigidbody>().velocity = new Vector3(moveSpeed, 0, 0);
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            moveSpeed = 0;
        }

        // print(rotateTracker.getOrientation());

        if (!gameOver)
        {

        

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

            //Vector3 temp = new Vector3(0, 0, 30);
            //GetComponent<Rigidbody>().AddRelativeForce(temp);




            Vector3 keyPos = new Vector3(lastXPos, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, keyPos, lerpSpeed);

            //lastZPos = transform.position.z; //keep last Z pos in case of rotation;

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

            //Vector3 temp = new Vector3(-30, 0, 0);
            //GetComponent<Rigidbody>().AddRelativeForce(temp);




            Vector3 keyPos = new Vector3(transform.position.x, transform.position.y, lastZPos);
            transform.position = Vector3.Lerp(transform.position, keyPos, lerpSpeed);

            //lastXPos = transform.position.x;
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



            Vector3 keyPos = new Vector3(transform.position.x, transform.position.y, lastZPos);
            transform.position = Vector3.Lerp(transform.position, keyPos, lerpSpeed);

            //lastXPos = transform.position.x;
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

            //Vector3 temp = new Vector3(0, 0, -30);
            //GetComponent<Rigidbody>().AddRelativeForce(temp);



            Vector3 keyPos = new Vector3(lastXPos, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, keyPos, lerpSpeed);

            //lastZPos = transform.position.z; //keep last Z pos in case of rotation;

        }
        }



        //print(Input.GetAxis("Horizontal"));

        //input movement
        //transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

        //Automove
        // Vector3 movement = new Vector3(0.0f, 0.0f, 1f);
        //GetComponent<Rigidbody>().velocity = movement * moveSpeed;


        if (rb.velocity.magnitude > moveSpeed && !superSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        if (gameController.getBoost() <= 0) {
            superSpeed = false;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Junction")
        {


            if (rotateTracker.getOrientation() == "up" || rotateTracker.getOrientation() == "down")
            {
                print("PLZZZ");
                changeLastZ(other.transform.position.z);
            }
            else if (rotateTracker.getOrientation() == "left" || rotateTracker.getOrientation() == "right")
            {
                changeLastX(other.transform.position.x);
            }

            //this.gameObject.SetActive(false);
        }
    }

    public void superSpeedPress()
    {
        if (gameController.boostButton.GetComponent<Button>().IsInteractable())
        {
            superSpeed = true;
        }
        else
        {
            //do nothing
        }

		
        
    }

    public void superSpeedRelease()
    {

        if (gameController.boostButton.GetComponent<Button>().IsInteractable())
        {
            superSpeed = false;
        }
        else
        {
            //do nothing
        }
       

        /*
        if (gameController.canBoost()) {
        } else
            gameController.disableBoost();
            */
    }

    public bool getSuperSpeed()
    {
        return superSpeed;
    }

    public void setMoveSpeed(float m)
    {
        moveSpeed = m;
    }


    public void changeLastX(float x)
    {
        lastXPos = x;
    }

    public void changeLastZ(float z)
    {
        lastZPos = z;
    }

    public void setGameOver()
    {
        gameOver = true;
		gameController.setGameOver();
    }

    public float getMoveSpeed()
    {
        return moveSpeed;

    }
}

