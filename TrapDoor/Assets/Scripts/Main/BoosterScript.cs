using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoosterScript : MonoBehaviour {

    public GameObject player;
    public GameObject superEffect;
    ParticleSystem.EmissionModule em;

    // Use this for initialization
    void Start () {
        em = superEffect.GetComponent<ParticleSystem>().emission;
    }
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerMovement>().getSuperSpeed())
        {
            GetComponent<ParticleSystem>().startSize = 3;
            em.enabled = true;

        }
        else
        {
            GetComponent<ParticleSystem>().startSize = 0.8f;
            em.enabled = false;
        }

    }
}
