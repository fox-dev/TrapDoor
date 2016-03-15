using UnityEngine;
using System.Collections;

public class BoosterScript : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerMovement>().getSuperSpeed())
        {
            GetComponent<ParticleSystem>().startSize = 2;
        }
        else
        {
            GetComponent<ParticleSystem>().startSize = 0.8f;
        }
	
	}
}
