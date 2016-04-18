﻿using UnityEngine;
using System.Collections;

public class SetPieceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform subchild in child)
            {
               
                foreach (Transform subchilds in child)
                {
                    subchilds.gameObject.SetActive(true);
                }
                subchild.gameObject.SetActive(true);
            }
            child.gameObject.SetActive(true);
        }
    }
}
