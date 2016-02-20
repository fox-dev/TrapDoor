using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;

    Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //print(Input.GetAxis("Horizontal"));

        //input movement
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

        //Automove
        // Vector3 movement = new Vector3(0.0f, 0.0f, 1f);
        //GetComponent<Rigidbody>().velocity = movement * moveSpeed;
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);

        if (rb.velocity.magnitude > moveSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }



    }
}
