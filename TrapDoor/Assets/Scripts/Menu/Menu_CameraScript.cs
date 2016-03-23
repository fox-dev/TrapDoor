using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu_CameraScript : MonoBehaviour
{
    public float menu_pos_z;

    public GameObject player;

    private RotateManager rotateTracker;

    private Vector3 followPos;

    private Vector3 followAngle;
    private Vector3 targetAngle;

    private Vector3 currentAngle;

    private GameController gameController;

    Vector3 endPos;
    bool end; //for camera zoom on gameOver

    bool startGame; //for camera zoom at start of game


    // Use this for initialization
    void Start()
    {
        GetComponent<Camera>().fieldOfView = 34;

        startGame = false;
        end = false; 

        GameObject rotateTrackerObject = GameObject.FindWithTag("Rotator");
        if (rotateTrackerObject != null)
        {
            rotateTracker = rotateTrackerObject.GetComponent<RotateManager>();
        }
        if (rotateTracker == null)
        {
            Debug.Log("Cannot find 'rotator' script");
        }

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        currentAngle = transform.eulerAngles;

        if(!(SceneManager.GetActiveScene().name == "Menu"))
        {
            StartCoroutine(moveCameraDelay());
        }
        


    }

    void Update()
    {
        if (startGame)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 61f, 0.02f);
            menu_pos_z = Mathf.Lerp(menu_pos_z, 15f, 0.02f);
            if(Camera.main.fieldOfView > 60f)
            {
                gameObject.GetComponent<Menu_CameraScript>().enabled = false;
            }
     
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (rotateTracker.getOrientation() == "down")
        {
            targetAngle = new Vector3(90f, 180f, 0);
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 2.5f));

            transform.eulerAngles = currentAngle;

            if (this.tag == "BackgroundCam") //not necessary if cam is child of player;
            {

                followPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.position = followPos;
            }
            else
            {
                Vector3 follow = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + menu_pos_z);
                //followPos = Vector3.Lerp(transform.position, follow, Time.deltaTime * 10);
                transform.position = follow;
                if (!gameController.getGameOver())
                    gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, transform.position.z);
            }

        }


        if (rotateTracker.getOrientation() == "left")
        {


            targetAngle = new Vector3(90f, 90f, 0);
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 2.5f));

            transform.eulerAngles = currentAngle;

            if (this.tag == "BackgroundCam")
            {
                followPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = followPos;
            }
            else
            {
                Vector3 follow2 = new Vector3(player.transform.position.x - 15, transform.position.y, player.transform.position.z);
                followPos = Vector3.Lerp(transform.position, follow2, Time.deltaTime * 10);
                if (!gameController.getGameOver())
                    gameObject.transform.position = new Vector3(followPos.x, gameObject.transform.position.y, player.transform.position.z);

            }


        }

        if (rotateTracker.getOrientation() == "right")
        {
            targetAngle = new Vector3(90f, 270f, 0);
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 2.5f));

            transform.eulerAngles = currentAngle;

            if (this.tag == "BackgroundCam")
            {

                followPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = followPos;
            }
            else
            {
                Vector3 follow2 = new Vector3(player.transform.position.x + 15, transform.position.y, player.transform.position.z);
                followPos = Vector3.Lerp(transform.position, follow2, Time.deltaTime * 10);
                if (!gameController.getGameOver())
                    gameObject.transform.position = new Vector3(followPos.x, gameObject.transform.position.y, player.transform.position.z);
            }


        }

        if (rotateTracker.getOrientation() == "up")
        {
            targetAngle = new Vector3(90f, 0f, 0);
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 2.5f));

            transform.eulerAngles = currentAngle;


            if (this.tag == "BackgroundCam")
            {
                followPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.position = followPos;
            }
            else
            {
                Vector3 follow = new Vector3(player.transform.position.x + 100, transform.position.y, player.transform.position.z - 15);
                followPos = Vector3.Lerp(transform.position, follow, Time.deltaTime * 10);
                if (!gameController.getGameOver())
                    gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, followPos.z);
            }


        }

        if (gameController.getGameOver())
        {
            if (!end)
            {
                if (rotateTracker.getOrientation() == "down")
                {
                    endPos = new Vector3(transform.position.x, transform.position.y - 50f, transform.position.z - 20f);
                }
                if (rotateTracker.getOrientation() == "up")
                {
                    endPos = new Vector3(transform.position.x, transform.position.y - 50f, transform.position.z + 20f);
                }
                if (rotateTracker.getOrientation() == "left")
                {
                    endPos = new Vector3(transform.position.x + 20f, transform.position.y - 50f, transform.position.z);
                }
                if (rotateTracker.getOrientation() == "right")
                {
                    endPos = new Vector3(transform.position.x - 20f, transform.position.y - 50f, transform.position.z);
                }

                end = true;
            }
            if (this.tag == "MainCamera")
                transform.position = Vector3.Lerp(transform.position, endPos, 0.05f);
        }


    }

    IEnumerator moveCameraDelay()
    {
        yield return new WaitForSeconds(1f); //wait 3 seconds after game starts

        startGame = true;

        
    }
}
