using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour {
	private Transform tr;
	private Transform mainCam;
	Quaternion rotation;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		mainCam = Camera.main.transform;
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		tr.LookAt (mainCam);
		transform.rotation = rotation;
	}
}
