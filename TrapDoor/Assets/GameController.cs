using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private bool red, green, blue;

	public GameObject scoreText;
	public GameObject redBorder, blueBorder, greenBorder;

	public Image boostBar;

	public GameObject boostButton;

	public GameObject gameOverlay;

	public GameObject restartButton;
	public GameObject restartButton_lerpPos;

	public float maxBoostValue, boostMeter, boostThreshold;

	private int score;

	public bool gameOver;

	float lerpValue = 0.05f;



	// Use this for initialization
	void Start () {

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
	}

	// Update is called once per frame
	void Update () {

		UpdateBoost();


		if (gameOver)
		{
			foreach(Transform child in gameOverlay.transform)
			{
				if(child.tag == "Untagged")
				{
					child.gameObject.SetActive(false);
				}
			}
			lerpButtons();
		}

		//Activates the boost button after the meter is 30% full
		if (canBoost())
			enableBoost();

	}

	public void RedPress()
	{
		if (red) {
			red = false;
			redBorder.SetActive (false);
		} else {
			red = true;
			redBorder.SetActive (true);
		}
		blue = false;
		green = false;
		blueBorder.SetActive (false);
		greenBorder.SetActive (false);
	}

	public void GreenPress()
	{
		if (green) {
			green = false;
			greenBorder.SetActive (false);
		} else {
			green = true;
			greenBorder.SetActive (true);
		}
		blue = false;
		red = false;
		blueBorder.SetActive (false);
		redBorder.SetActive (false);
	}

	public void BluePress()
	{
		if (blue) {
			blue = false;
			blueBorder.SetActive (false);
		} else {
			blue = true;
			blueBorder.SetActive (true);
		}
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

	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	//Boost meter scripts
	public void addBoost(float newBoostValue)
	{
		boostMeter += newBoostValue;
		if (boostMeter > maxBoostValue) {
			print ("Im Triggered");
			boostMeter = maxBoostValue;
		}

	}

	public void decBoost(float newBoostValue)
	{
		boostMeter -= newBoostValue;
		if (boostMeter <= 0f) {
			boostMeter = 0f;
			disableBoost ();
		}
	}

	public float getBoost()
	{
		return boostMeter;
	}

	public bool canBoost()
	{
		if ((boostMeter / maxBoostValue) > boostThreshold)
			return true;
		else
			return false;
	}

	public void disableBoost()
	{
        //boostButton.SetActive(false

        boostButton.GetComponent<Button>().interactable = false;
	}

	public void enableBoost()
	{
		boostButton.SetActive(true);
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

	public void lerpButtons()
	{
		restartButton.transform.position = Vector3.Lerp(restartButton.transform.position, restartButton_lerpPos.transform.position, lerpValue);
	}

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

}