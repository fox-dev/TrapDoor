using UnityEngine;
using System.Collections;

public class PlanetFollow : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            print("leaving");
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z*2);

        }


            
    }
}
