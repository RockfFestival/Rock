using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour {
	private Transform tr;
    private Transform stone;
	private Transform mainCam;
	Quaternion rotation;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
        stone = transform.parent;
		mainCam = Camera.main.transform;
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		tr.LookAt (mainCam);
        tr.position = new Vector3(stone.position.x, stone.position.y + 3.0f, stone.position.z);
		transform.rotation = rotation;
	}
}
