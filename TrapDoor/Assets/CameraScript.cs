using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


    public GameObject player;
    private Vector3 followPos;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 follow = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 15);
        followPos = Vector3.Lerp(transform.position, follow, Time.deltaTime * 2);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, followPos.z);
    }
}
