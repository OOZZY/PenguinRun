﻿using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	public Camera cam1;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		cam1.enabled = true;
		cam2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
		}
	}
}
