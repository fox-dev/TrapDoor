using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    private GameController gameController;
	private AdController adController;

    public GameObject highScoreText;
    public GameObject highScoreText_Pos;

    public GameObject scoreText;
    public GameObject scorePos;

    public GameObject restartButton;
    public GameObject restartButton_Pos;

    public GameObject menuButton;
    public GameObject menuButton_Pos;

    //UI Button Positions
    public GameObject gameUI;
    public Transform left, right;

    float lerpValue = 0.05f;

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.GetString("ui") == "left")
        {
            gameUI.transform.position = left.position;
        }
        else if (PlayerPrefs.GetString("ui") == "right")
        {
            gameUI.transform.position = right.position;
        }
        else //default
        {
            gameUI.transform.position = right.position;
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

		GameObject adControllerObject = GameObject.FindWithTag("AdController");
		if (adControllerObject != null)
		{
			adController = adControllerObject.GetComponent<AdController>();
		}
		if (adController == null)
		{
			Debug.Log("Cannot find 'AdController' script");
		}
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (gameController.getGameOver())
        {
            gameOverStuff();
            lerpStuff();
        }
	
	}

    void gameOverStuff()
    {
			
		if (gameController.getScore() > gameController.getHighScore())
        {
            PlayerPrefs.SetInt("highscore", gameController.getScore());
            highScoreText.GetComponent<Text>().text = "New Highscore: " + gameController.getScore();
        }
        else
        {
            highScoreText.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("highscore");
        }

		if (adController.AdFlag ()) {
			adController.showBannerAd ();
			if (adController.adIsLoaded ()) {
				adController.showIntAd ();
			}
		}


    }

    void lerpStuff()
    {
        highScoreText.transform.position = Vector3.Lerp(highScoreText.transform.position, highScoreText_Pos.transform.position, lerpValue);
        scoreText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        scoreText.transform.position = Vector3.Lerp(scoreText.transform.position, scorePos.transform.position, lerpValue);

        restartButton.transform.position = Vector3.Lerp(restartButton.transform.position, restartButton_Pos.transform.position, lerpValue);
        menuButton.transform.position = Vector3.Lerp(menuButton.transform.position, menuButton_Pos.transform.position, lerpValue);
    }

    public void LoadScene(string name)
    {
		if (adController.AdFlag ()) {
			
			adController.getNewAds();
			adController.hideBannerAd ();
		}

		SceneManager.LoadScene(name);
    }
}
