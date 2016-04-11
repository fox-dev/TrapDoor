using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	private AdController adController;

	//Highscore Canvas buttons and text
    public Button highScoreButton, resetButton, highScore_backButton;
    private bool openHighScore;
    public Canvas highScore_Canvas;
    public Transform highScorePos_Off;
    public GameObject highScoreText;
    public GameObject resetScorePanel;

    //Options Canvas buttons and text
    private bool openOptions;
    public Canvas options_Canvas;
    public Transform optionsPos_Off;
    private bool lefty, righty;
    public Button leftButton, rightButton, options_backButton, onButton, offButton;

	//Tutorial Canvas buttons and text
	private bool openTutorial, openTutorial2;
	public Canvas tutorial_Canvas, tutorial_Canvas2;
	public Transform mainMenu_Off, mainMenu_On, tutorial_Off;
	public GameObject menu;
	public Camera main, tutorial;

    float lerpValue = 0.5f;

    public Transform CanvasPos_On;



    // Use this for initialization
    void Start () {
        
		GameObject adControllerObject = GameObject.FindWithTag("AdController");
		if (adControllerObject != null)
		{
			adController = adControllerObject.GetComponent<AdController>();
		}
		if (adController == null)
		{
			Debug.Log("Cannot find 'AdController' script");
		}

        updateOptions();

        openHighScore = false;
        openOptions = false;

        resetScorePanel.gameObject.SetActive(false);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        lerpCanvas();
       
    }


    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }


    //////////////HIGH SCORE CANVAS BUTTONS////////////////
    public void openHighScoreCanvas()
    {
        highScoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();

        if (PlayerPrefs.GetInt("highscore") == 0)
        {
            resetButton.gameObject.SetActive(false);
        }

        openHighScore = true;
    }

    public void closeHighScoreCanvas()
    {
        openHighScore = false;
    }

    public void resetScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
        highScoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
        
        resetScorePanel.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("highscore") == 0)
        {
            resetButton.gameObject.SetActive(false);
        }
    }

    public void openConfirmResetScore()
    {
        resetScorePanel.SetActive(true);
        resetButton.gameObject.SetActive(false);
    }

    public void closeConfirmResetScore()
    {
        resetScorePanel.SetActive(false);
        resetButton.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("highscore") == 0)
        {
            resetButton.gameObject.SetActive(false);
        }
    }


    //////////////OPTIONS CANVAS BUTTONS////////////////
    public void openOptionsCanvas()
    {
        openOptions = true;
    }

    public void closeOptionsCanvas()
    {
        openOptions = false;
    }

    void updateOptions()
    {

        if (PlayerPrefs.GetString("ui") == "left")
        {
            lefty = true;
        }
        else if (PlayerPrefs.GetString("ui") == "right")
        {
            righty = true;
        }
        else //default
        {
            righty = true;
        }

        if (lefty)
        {
            leftButton.interactable = false;
            righty = false;
            rightButton.interactable = true;
        }
        else if (righty)
        {
            rightButton.interactable = false;
            lefty = false;
            leftButton.interactable = true;
        }


		if (PlayerPrefs.GetString ("ads") == "false") {
			adController.setAdFlag (false);
		} else { //default
			adController.setAdFlag (true);;
		}

		if (adController.AdFlag())
		{
			onButton.interactable = false;
			offButton.interactable = true;
		}
		else
		{
			offButton.interactable = false;
			onButton.interactable = true;
		}
    }

	public void turnLeftyOn()
	{
		lefty = true;
		PlayerPrefs.SetString("ui", "left");
		leftButton.interactable = false;
		if (righty)
		{
			righty = false;
			rightButton.interactable = true;
		}

	}

	public void turnRightyOn()
	{
		PlayerPrefs.SetString("ui", "right");
		righty = true;
		rightButton.interactable = false;
		if (lefty)
		{
			lefty = false;
			leftButton.interactable = true;
		}
	}

	public void turnOffAds()
	{
		adController.setAdFlag (false);
		PlayerPrefs.SetString("ads", "false");
		onButton.interactable = true;
		offButton.interactable = false;
	}

	public void turnOnAds()
	{
		adController.setAdFlag (true);
		PlayerPrefs.SetString("ads", "true");
		offButton.interactable = true;
		onButton.interactable = false;
	}

    /// <summary>
    /// ////////////////////Tutorial Canvas//////////////////////////////////////
    
	public void openTutorialCanvas()
	{
		openTutorial = true;
	}

	public void closeTutorialCanvas()
	{
		openTutorial = false;
	}

	public void openTutorialCanvas2()
	{
		openTutorial2 = true;
		closeTutorialCanvas ();
	}

	public void closeTutorialCanvas2()
	{
		openTutorial2 = false;
	}



    //Open Canvas
    public void lerpCanvas()
    {
        if (openHighScore)
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, CanvasPos_On.position, lerpValue);
        }
        else
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, highScorePos_Off.position, lerpValue);
        }

        if (openOptions)
        {
            options_Canvas.transform.position = Vector3.Lerp(options_Canvas.transform.position, CanvasPos_On.position, lerpValue);
        }
        else
        {
            options_Canvas.transform.position = Vector3.Lerp(options_Canvas.transform.position, optionsPos_Off.position, lerpValue);
        }

		if (openTutorial)
		{
			tutorial_Canvas.transform.position = Vector3.Lerp(tutorial_Canvas.transform.position, CanvasPos_On.position, lerpValue);
			menu.transform.position = Vector3.Lerp(menu.transform.position, mainMenu_Off.position, lerpValue);
			main.gameObject.SetActive (false);
			tutorial.gameObject.SetActive (true);
		}
		else
		{
			tutorial_Canvas.transform.position = Vector3.Lerp(tutorial_Canvas.transform.position, tutorial_Off.position, lerpValue);
			menu.transform.position = Vector3.Lerp(menu.transform.position, mainMenu_On.position, lerpValue);
			main.gameObject.SetActive (true);
			tutorial.gameObject.SetActive (false);
		}

		if (openTutorial2)
		{
			tutorial_Canvas.transform.position = Vector3.Lerp(tutorial_Canvas2.transform.position, CanvasPos_On.position, lerpValue);
			menu.transform.position = Vector3.Lerp(menu.transform.position, mainMenu_Off.position, lerpValue);
			main.gameObject.SetActive (false);
			tutorial.gameObject.SetActive (true);
		}
		else
		{
			tutorial_Canvas.transform.position = Vector3.Lerp(tutorial_Canvas2.transform.position, tutorial_Off.position, lerpValue);
			menu.transform.position = Vector3.Lerp(menu.transform.position, mainMenu_On.position, lerpValue);
			main.gameObject.SetActive (true);
			tutorial.gameObject.SetActive (false);
		}
    }


}
