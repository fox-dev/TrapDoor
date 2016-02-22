using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x;
        offset.y = transform.position.z / transform.localScale.z;


        mat.mainTextureOffset = offset;



       
	
	}
}
