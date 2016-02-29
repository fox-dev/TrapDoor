using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExitBoundary : MonoBehaviour {

    public GameObject boundary;
    public GameObject player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Set")
        {
            print("GOT IT!");

            boundary.GetComponent<Boundary>().addToInactivePieces(other);
           
        }

        if (other.tag == "Junction")
        {
            print("GOT IT!");
            boundary.GetComponent<Boundary>().addToInactivePieces(other);


        }
    }
}
