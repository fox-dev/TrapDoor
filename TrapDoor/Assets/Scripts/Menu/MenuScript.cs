using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    //Highscore Canvas buttons and text
    public Button highScoreButton, resetButton, highScore_backButton;
    private bool openHighScore;
    public Canvas highScore_Canvas;
    public Transform highScorePos_On, highScorePos_Off;
    public GameObject highScoreText;
    public GameObject resetScorePanel;
   

    float lerpValue = 0.5f;



    // Use this for initialization
    void Start () {

        openHighScore = false;
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

    public void lerpCanvas()
    {
        if (openHighScore)
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, highScorePos_On.position, lerpValue);
        }
        else
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, highScorePos_Off.position, lerpValue);
        }
    }


}
