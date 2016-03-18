using UnityEngine;
using System.Collections;

public class DoorAudio : MonoBehaviour {

    private GameController gameController;

    private bool hasPlayedBlue, hasPlayedRed, hasPlayedGreen;

    private AudioSource aud;

    // Use this for initialization
    void Start () {



        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        aud = GetComponent<AudioSource>();

        hasPlayedRed = false;
        hasPlayedGreen = false;
        hasPlayedBlue = false;
    }
	
	// Update is called once per frame
	void Update () {


        //DOORS OPENING
        if (gameController.getBlue() && !hasPlayedBlue && this.tag == "BlueAudio")
        {
            print("BLUEOPEN");
            aud.Play();
            hasPlayedBlue = true;
            hasPlayedRed = false;
            hasPlayedGreen = false;

        }

        else if (gameController.getRed() && !hasPlayedRed && this.tag == "RedAudio")
        {
            print("REDOPEN");
            aud.Play();
            hasPlayedRed = true;
            hasPlayedBlue = false;
            hasPlayedGreen = false;

        }
        else if (gameController.getGreen() && !hasPlayedGreen && this.tag == "GreenAudio")
        {
            print("GREENOPEN");
            aud.Play();
            hasPlayedGreen = true;
            hasPlayedRed = false;
            hasPlayedBlue = false;
        }


        //DOORS CLOSING
        if (!gameController.getBlue() && hasPlayedBlue && this.tag == "BlueAudio")
        {
            print("BLUECLOSE");
            aud.Play();
            hasPlayedBlue = false;
            

        }

        else if (!gameController.getRed() && hasPlayedRed && this.tag == "RedAudio")
        {
            print("REDCLOSE");
            aud.Play();
            hasPlayedRed = false;
            

        }
        else if (!gameController.getGreen() && hasPlayedGreen && this.tag == "GreenAudio")
        {
            print("GREENCLOSE");
            aud.Play();
            hasPlayedGreen = false;
           
        }

    }
}


/*
if (aud == null)
            {

            }
            else
            {
                if(!aud.isPlaying && hasPlayed == false)
                {
                    aud.PlayOneShot(aud.clip);
                    print("AUDIOS");
                    hasPlayed = true;
                }
                
            }
*/