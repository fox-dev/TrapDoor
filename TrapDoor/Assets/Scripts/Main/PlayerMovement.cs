using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public int health;

    public GameObject healthCanvas, healthBar;

    AudioSource hit, lowHP;

    public GameObject playerModel, boundary;

    public GameObject theModel;

    private GameController gameController;

    private RotateManager rotateTracker;

	public float moveSpeed, superMoveSpeed;

    private Vector3 currentAngle, targetAngle;

    public float lastXPos, lastYPos, lastZPos;

    Rigidbody rb;

    private bool superSpeed;

    public float lerpSpeed;

    public bool gameOver;

    private bool blinking;

    private bool playingSuper;





    // Use this for initialization
    void Start() {

        AudioSource[] playerAudioSources = GetComponents<AudioSource>();
        hit = playerAudioSources[0];
        lowHP = playerAudioSources[1];

        health = 3;
        healthBar = healthCanvas.transform.FindChild("HealthBar").gameObject;


        playingSuper = false; //audio for boost

        blinking = false;

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
            playSuperSound();
			gameController.decrementBoost();
            
        }
        else
        {
            stopSuperSound();
            
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
        else if (!gameOver)
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
			gameController.onPressDecrement();
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

    public bool isDead()
    {
        return (health <= 0);
    }



    public void blink()
    {
        //theModel.GetComponent<Renderer>().enabled = false;
        if (!blinking)
        {
            blinking = true;
            StartCoroutine(TakeDamage(0.3f, 0.2f));

            hit.Play();
            if (health == 1)
            {
                lowHP.Play();
            }
        }

    }

    public bool invulnerable()
    {
        return blinking;
    }

    IEnumerator TakeDamage(float duration, float blinkTime) //duration is seconds/10 to properly subtract deltatime
    {
        health--;
        /*
        Mathf.MoveTowards(boostBar.fillAmount, boostMeter / 100, Time.deltaTime * 2f);
        healthBar.GetComponent<Image>().fillAmount
        */
        if (health == 2)
        {
            healthBar.GetComponent<Image>().fillAmount = 0.565f;
        }
        else if (health == 1)
        {
            healthBar.GetComponent<Image>().color = Color.red;
            healthBar.GetComponent<Image>().fillAmount = 0.345f;
        }
        else if (health == 0)
        {
            setGameOver();
            healthBar.GetComponent<Image>().fillAmount = 0f;
        }


        while (duration > 0f && health > 0) //divied by 10 to properly have delta time subtract in seconds.
        {

            //print("dur: " + duration);
            duration -= Time.fixedDeltaTime;



            //Toggle renderer
            theModel.GetComponent<Renderer>().enabled = !theModel.GetComponent<Renderer>().enabled;
            healthCanvas.SetActive(true);


            //Wait for a bit
            yield return new WaitForSeconds(blinkTime);

        }
        theModel.GetComponent<Renderer>().enabled = true;
        healthCanvas.SetActive(false);
        blinking = false;

    }

    public void playSuperSound()
    {
        if (!playingSuper)
        {
            playingSuper = true;
            GetComponents<AudioSource>()[3].Play();
            

        }
        GetComponents<AudioSource>()[3].volume = Mathf.Lerp(GetComponents<AudioSource>()[2].volume, 1f, 0.02f);
        GetComponents<AudioSource>()[2].volume = Mathf.Lerp(GetComponents<AudioSource>()[2].volume, 1f, 0.05f);
    }

    public void stopSuperSound()
    {
        if (playingSuper)
        {
            playingSuper = false;
            


        }
        if (gameController.startGameReady()) //need this otherwise volume gets lowered too early
        {
            GetComponents<AudioSource>()[2].volume = Mathf.Lerp(GetComponents<AudioSource>()[2].volume, 0.21f, 0.02f);
            GetComponents<AudioSource>()[3].volume = Mathf.Lerp(GetComponents<AudioSource>()[2].volume, 0f, 0.05f);
            if(GetComponents<AudioSource>()[3].volume < 0.25f)
            {
                GetComponents<AudioSource>()[3].Stop();
            }
        }
        
    }


}

