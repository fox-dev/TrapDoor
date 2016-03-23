using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boundary : MonoBehaviour {

    public List<GameObject> activePieces;

    public List<GameObject> mediumSet; //med difficulty array to switch to
    public int med_scoreThreshold;

    private GameController gameController;

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
            Debug.Log("Cannot find 'RotateManager' script");
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

        setRandomRotation();

    }
	
	// Update is called once per frame
	void Update () {
        orientation = rotateTracker.getOrientation();

        //print("Current rot:" + rotateTracker.getOrientation());

        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Set")//for normal use and no junction is entered
		{
            //print("Placing set");

            if(gameController.getScore() < med_scoreThreshold)
            {
                toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                inactivePieces.Remove(toPlace);
            }
            else if(gameController.getScore() >= med_scoreThreshold)
            {
                toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                mediumSet.Remove(toPlace);
            }
            
			

			if (rotateTracker.getOrientation() == "down")
			{

				if (toPlace.tag != "Junction")
				{
					toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
					toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 154);

				}
				else
				{
					toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
					toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 231);
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
					toPlace.transform.position = new Vector3(other.transform.position.x - 231, other.transform.position.y, other.transform.position.z);
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
					toPlace.transform.position = new Vector3(other.transform.position.x + 231f, other.transform.position.y, other.transform.position.z);
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
					toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 231f);
				}

			}

			toPlace.gameObject.SetActive(true); //enable piece
		}
		else if (other.tag == "Junction")
		{
			//print("Placing junction");
			//other.GetComponent<Rotation>().setRotateTo(rotateTo);
			bool found1 = false;
			while (found1 == false) //get set piece that is not another junction
			{
                if (gameController.getScore() < med_scoreThreshold)
                {
                    toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                    mediumSet.Remove(toPlace);
                }
                if (toPlace.tag == "Junction")
				{
					found1 = false;
				}
				else
				{
					found1 = true;
				}
			}

            if (gameController.getScore() < med_scoreThreshold)
            {
              
                inactivePieces.Remove(toPlace);
            }
            else if (gameController.getScore() >= med_scoreThreshold)
            {
               
                mediumSet.Remove(toPlace);
            }
    

			if (rotateTracker.getOrientation() == "down") //down orientation to left or right
			{
				toPlace.transform.rotation = Quaternion.Euler(0, 270, 0); //first piece
				toPlace.transform.position = new Vector3(other.transform.position.x - 77, other.transform.position.y, other.transform.position.z);
				toPlace.gameObject.SetActive(true);

				bool found2 = false;
				while (found2 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                      
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                       
                    }

                    if (toPlace.tag == "Junction")
					{
						found2 = false;
					}
					else
					{
						found2 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                   
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x + 77, other.transform.position.y, other.transform.position.z);
				toPlace.gameObject.SetActive(true);



				bool found3 = false;
				while (found3 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                        
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                        
                    }

                    if (toPlace.tag == "Junction")
					{
						found3 = false;
					}
					else
					{
						found3 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                   
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                   
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 77);
				toPlace.gameObject.SetActive(true);

			}
			else if (rotateTracker.getOrientation() == "left") //left orientation to up or down
			{

				toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 77);
				toPlace.gameObject.SetActive(true);

				bool found2 = false;
				while (found2 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                      
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                        
                    }

                    if (toPlace.tag == "Junction")
					{
						found2 = false;
					}
					else
					{
						found2 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                    
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 77);
				toPlace.gameObject.SetActive(true);


				bool found3 = false;
				while (found3 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                       
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                       
                    }

                    if (toPlace.tag == "Junction")
					{
						found3 = false;
					}
					else
					{
						found3 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                    
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x - 77, other.transform.position.y, other.transform.position.z);
				toPlace.gameObject.SetActive(true);

			}

			else if (rotateTracker.getOrientation() == "right") //left orientation to up or down
			{
				toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 77);
				toPlace.gameObject.SetActive(true);

				bool found2 = false;
				while (found2 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                        
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                        
                    }

                    if (toPlace.tag == "Junction")
					{
						found2 = false;
					}
					else
					{
						found2 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                   
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 0, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 77);
				toPlace.gameObject.SetActive(true);


				bool found3 = false;
				while (found3 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                        
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                        
                    }

                    if (toPlace.tag == "Junction")
					{
						found3 = false;
					}
					else
					{
						found3 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                    
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x + 77, other.transform.position.y, other.transform.position.z);
				toPlace.gameObject.SetActive(true);

			}

			else if (rotateTracker.getOrientation() == "up") //up orientation to left or right
			{
				toPlace.transform.rotation = Quaternion.Euler(0, 270, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x - 77, other.transform.position.y, other.transform.position.z);
				toPlace.gameObject.SetActive(true);



				bool found2 = false;
				while (found2 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                        
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                        
                    }

                    if (toPlace.tag == "Junction")
					{
						found2 = false;
					}
					else
					{
						found2 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                    
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                   
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 90, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x + 77, other.transform.position.y, other.transform.position.z);
				toPlace.gameObject.SetActive(true);



				bool found3 = false;
				while (found3 == false) //get set piece that is not another junction
				{
                    if (gameController.getScore() < med_scoreThreshold)
                    {
                        toPlace = inactivePieces[Random.Range(0, inactivePieces.Count)]; //get set piece to place
                        
                    }
                    else if (gameController.getScore() >= med_scoreThreshold)
                    {
                        toPlace = mediumSet[Random.Range(0, mediumSet.Count)];
                        
                    }

                    if (toPlace.tag == "Junction")
					{
						found3 = false;
					}
					else
					{
						found3 = true;
					}
				}

                if (gameController.getScore() < med_scoreThreshold)
                {
                   
                    inactivePieces.Remove(toPlace);
                }
                else if (gameController.getScore() >= med_scoreThreshold)
                {
                    
                    mediumSet.Remove(toPlace);
                }

                toPlace.transform.rotation = Quaternion.Euler(0, 180, 0);
				toPlace.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 77);
				toPlace.gameObject.SetActive(true);

			}

		}
	}

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Junction")
        {
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

    public void addToInactivePieces(Collider other)
    {

        other.gameObject.SetActive(false);
        if(gameController.getScore() < med_scoreThreshold)
        {
            inactivePieces.Add(other.gameObject);
        }
        else if(gameController.getScore() >= med_scoreThreshold)
        {
            mediumSet.Add(other.gameObject);
        }



    }



}
