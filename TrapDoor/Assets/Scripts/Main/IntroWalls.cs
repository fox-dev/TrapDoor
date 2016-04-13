using UnityEngine;
using System.Collections;

public class IntroWalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Transform>().gameObject.SetActive(false);
        }
    }
}
