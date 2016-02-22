using UnityEngine;
using System.Collections;

public class RotateManager : MonoBehaviour {

    private string rotation;

	// Use this for initialization
	void Start () {

        rotation = "down"; //up, down, left, right

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public string getOrientation()
    {
        return rotation;
    }

    public void setRotation(string s)
    {
        rotation = s;
    }
}
