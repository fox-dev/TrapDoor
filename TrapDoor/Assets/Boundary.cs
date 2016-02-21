using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Set")
        {
            other.gameObject.SetActive(false);
            if(transform.rotation.y == 0)
            {
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 200f);
            }
            else
            {
                other.transform.position = new Vector3(other.transform.position.x - 200f, other.transform.position.y, other.transform.position.z);
            }
         
            other.gameObject.SetActive(true);
        }
      
    }


}
