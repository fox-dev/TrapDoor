using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameObject model, boundary;

    public float moveSpeed;

    float start;

    bool rotate,ready;

    Rigidbody rb;

    private Vector3 currentAngle, targetAngle;

	// Use this for initialization
	void Start () {

        rotate = false;

        rb = GetComponent<Rigidbody>();

        currentAngle = transform.eulerAngles;
        targetAngle = new Vector3(0, 270f, 0);

        start = transform.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //print(start - transform.position.z);
        if (transform.position.z > 155f && !rotate)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rotate = true;
            
        }
        

        if(!rotate)
        {
            //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);

            Vector3 temp = new Vector3(0, 0, 30);
            GetComponent<Rigidbody>().AddRelativeForce(temp);

        }
        else if (rotate == true)
        {
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 5),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 5),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5));

            model.transform.eulerAngles = currentAngle;

            boundary.transform.rotation = Quaternion.Euler(0, 270, 0);

            
            Vector3 temp = new Vector3(-30, 0, 0);
            GetComponent<Rigidbody>().AddRelativeForce(temp);
        }

        
      

        //print(Input.GetAxis("Horizontal"));

        //input movement
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

        //Automove
        // Vector3 movement = new Vector3(0.0f, 0.0f, 1f);
        //GetComponent<Rigidbody>().velocity = movement * moveSpeed;
        

        if (rb.velocity.magnitude > moveSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }



    }
}
