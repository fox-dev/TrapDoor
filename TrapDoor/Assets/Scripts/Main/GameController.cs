using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private bool red, green, blue;

	public GameObject scoreText, multiplyText;
    public GameObject scorePos;

	public GameObject redBorder, blueBorder, greenBorder;

	public Image boostBar;

	public GameObject boostButton;

	public GameObject gameOverlay;

	public GameObject restartButton;
	public GameObject restartButton_lerpPos;

	public float maxBoostValue, boostMeter, boostThreshold, superDecAmount, superPressDecrement, wallPenalty, boostAddAmount;

    public GameObject player;

    private bool startGame; //used for when cameras are done transitioning into place


    //Score
    //Highscore
    //Score multiplier
    //Max score multiplier
    private int score, highScore, multiply, doorCounter;
    public int maxMultiply, incrementAt;

	public bool gameOver;

	float lerpValue = 0.05f;



	// Use this for initialization
	void Start () {

        startGame = false;

        if (PlayerPrefs.GetInt("highscore") != null)
        {
            highScore = PlayerPrefs.GetInt("highscore");
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        red = false;
		green = false;
		blue = false;

		redBorder.SetActive (false);
		greenBorder.SetActive (false);
		blueBorder.SetActive (false);

		score = 0;
		UpdateScore ();

		boostMeter = 0f;

		disableBoost();

		gameOver = false;

        multiply = 1;
	}

	// Update is called once per frame
	void Update () {

        UpdateScore();

        resetHighScore(); //for testing


        UpdateBoost();


		if (gameOver)
		{
			foreach(Transform child in gameOverlay.transform)
			{
				if(child.tag == "Untagged" || child.tag == "Score")
				{
					child.gameObject.SetActive(false);
				}
			}
		}

		//Activates the boost button after the meter is 30% full
		if (canBoost())
			enableBoost();

	}

	public void RedPress()
	{
		/*if (red) {
			red = false;
			redBorder.SetActive (false);
		} else {
			red = true;
			redBorder.SetActive (true);
		}*/
		red = true;
		redBorder.SetActive (true);
		blue = false;
		green = false;
		blueBorder.SetActive (false);
		greenBorder.SetActive (false);
	}

	public void GreenPress()
	{
		/*if (green) {
			green = false;
			greenBorder.SetActive (false);
		} else {
			green = true;
			greenBorder.SetActive (true);
		}*/
		green = true;
		greenBorder.SetActive (true);
		blue = false;
		red = false;
		blueBorder.SetActive (false);
		redBorder.SetActive (false);
	}

	public void BluePress()
	{
		/*if (blue) {
			blue = false;
			blueBorder.SetActive (false);
		} else {
			blue = true;
			blueBorder.SetActive (true);
		}*/
		blue = true;
		blueBorder.SetActive (true);
		red = false;
		green = false;
		redBorder.SetActive (false);
		greenBorder.SetActive (false);
	}

	public void getColorStates(ref bool r,ref bool g,ref bool b)
	{
		r = red;
		g = green;
		b = blue;
	}

	//Score Scripts
	void UpdateScore()
	{

		scoreText.GetComponent<Text>().text = "Score : " + score;
        multiplyText.GetComponent<Text>().text = "x" + multiply;

	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	//Boost meter scripts
	private void addBoost(float newBoostValue)
	{
		boostMeter += newBoostValue;
		if (boostMeter > maxBoostValue) {
			print ("Im Triggered");
			boostMeter = maxBoostValue;
		}

	}

	private void decBoost(float newBoostValue)
	{
		boostMeter -= newBoostValue;
		if (boostMeter <= 0f) {
			boostMeter = 0f;
			disableBoost ();
		}
	}

	//public access to boost

	public void decrementBoost ()
	{
		decBoost(superDecAmount);
	}

	public void onPressDecrement()
	{
		decBoost (superPressDecrement);
	}

	public void laserWallDecrement()
	{
		decBoost (wallPenalty);
	}

	public void incrementBoost()
	{
		addBoost (boostAddAmount);
	}




	public float getBoost()
	{
		return boostMeter;
	}

	public bool canBoost()
	{
		if ((boostMeter / maxBoostValue) >= boostThreshold)
			return true;
		else
			return false;
	}

	public void disableBoost()
	{
        //boostButton.SetActive(false);

        boostButton.GetComponent<Button>().interactable = false;
	}

	public void enableBoost()
	{
		//boostButton.SetActive(true);
        boostButton.GetComponent<Button>().interactable = true;
    }

	void UpdateBoost()
	{
		/*
		boostBar.rectTransform.localScale = new Vector3 (boostBar.rectTransform.localScale.x, 
														 boostMeter / maxBoostValue,
														 boostBar.rectTransform.localScale.z);
                                                         */

		boostBar.fillAmount = Mathf.MoveTowards(boostBar.fillAmount, boostMeter / 100, Time.deltaTime * 2f);

	}


	/// <summary>
	/// Loads the scene.
	/// </summary>
	/// <param name="name">Name.</param>
	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void setGameOver()
	{
		gameOver = true;
		
	}

	public bool getGameOver()
	{
		return gameOver;
	}

    public GameObject getPlayer()
    {
        return player;
    }

    public int getScore()
    {
        return score;
    }

    public int getHighScore()
    {
        return highScore;
    }

    public bool getRed()
    {
        return red;
    }

    public bool getGreen()
    {
        return green;
    }

    public bool getBlue()
    {
        return blue;
    }

    public void resetScoreMultiplier()
    {
        multiply = 1;
        doorCounter = 0;
    }

    public int getMultiplier()
    {
        return multiply;
    }

    public void incDoorCounter()
    {
       if(doorCounter < incrementAt)
        {
            doorCounter++;
        }

       if(doorCounter == incrementAt)
        {
            doorCounter = 0;

            if (multiply < maxMultiply)
            {
                multiply++;
            }
        }
    }

    public void resetHighScore()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Highscore reset");
            PlayerPrefs.SetInt("highscore", 0);
        }
    }

    public bool startGameReady()
    {
        return startGame;
    }

    //Used in menu_camerascript to determine when cameras are done with the start transition
    
    public void startGameTrue()
    {
        startGame = true;
    }
}