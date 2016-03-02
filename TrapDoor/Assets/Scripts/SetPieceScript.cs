using UnityEngine;
using System.Collections;

public class SetPieceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform subchild in child)
            {
                subchild.gameObject.SetActive(true);
            }
            child.gameObject.SetActive(true);
        }
    }
}
