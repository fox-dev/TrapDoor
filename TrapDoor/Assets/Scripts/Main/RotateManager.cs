using UnityEngine;
using System.Collections;

public class RotateManager : MonoBehaviour {

    private string rotation;

    private string turn;

	// Use this for initialization
	void Start () {

        rotation = "down"; //up, down, left, right
        turn = "down"; //up, down, left, right <- For junctions that are changing directions;

    }

    public string getOrientation()
    {
        return rotation;
    }

    public string getTurn()
    {
        return turn;
    }

    public void setRotation(string s)
    {
        
        if(rotation == "up" && s == "down")
        {

        }
        else if (rotation == "down" && s == "up")
        {

        }
        else if (rotation == "left" && s == "right")
        {

        }
        else if (rotation == "right" && s == "left")
        {

        }
        else
        {
            rotation = s;
        }
    }

    public void setTurn(string s)
    {
        turn = s;
    }
}


