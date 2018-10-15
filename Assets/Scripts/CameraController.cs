using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<Camera>().aspect = 1.778f;
	}
}
