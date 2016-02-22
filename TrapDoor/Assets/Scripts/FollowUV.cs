using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour {

    public float parallax;

    Quaternion rotation;

    void Awake()
    {
        rotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update () {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parallax;
        offset.y = transform.position.z / transform.localScale.z / parallax;


        mat.mainTextureOffset = offset;


        





    }
}
