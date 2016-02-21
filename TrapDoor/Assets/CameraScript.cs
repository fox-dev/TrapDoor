using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


    public GameObject player;
    private Vector3 followPos;

    private Vector3 followAngle;
    private Vector3 targetAngle;

    private Vector3 currentAngle;

    // Use this for initialization
    void Start () {

        currentAngle = transform.eulerAngles;
        targetAngle = new Vector3(90f, 90f, 0);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (player.transform.position.z < 155)
        {
            Vector3 follow = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + 15);
            followPos = Vector3.Lerp(transform.position, follow, Time.deltaTime * 2);
            gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, followPos.z);
        }


        if (player.transform.position.z > 155f)
        {
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 2.5f),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 2.5f));

            transform.eulerAngles = currentAngle;

            Vector3 follow2 = new Vector3(player.transform.position.x - 15, transform.position.y, player.transform.position.z);
            followPos = Vector3.Lerp(transform.position, follow2, Time.deltaTime * 2);
            gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, followPos.z);
        }

        
    }
}
