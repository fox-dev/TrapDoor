﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    //Highscore Canvas buttons and text
    public Button highScoreButton, resetButton, highScore_backButton;
    private bool openHighScore;
    public Canvas highScore_Canvas;
    public Transform highScorePos_Off;
    public GameObject highScoreText;
    public GameObject resetScorePanel;

    //Highscore Canvas buttons and text
    private bool openOptions;
    public Canvas options_Canvas;
    public Transform optionsPos_Off;
    private bool lefty, righty;
    public Button leftButton, rightButton, options_backButton;


    float lerpValue = 0.5f;

    public Transform CanvasPos_On;



    // Use this for initialization
    void Start () {
        
        

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
    }


}
