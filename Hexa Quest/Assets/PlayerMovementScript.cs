﻿using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            //transform.Rotate(new Vector3(0, -60, 0));
        }

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
           // iTween.RotateTo(gameObject, new Vector3(0, -60, 0), 0.4f);
    }
}
