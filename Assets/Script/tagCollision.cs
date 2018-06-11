using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagCollision : MonoBehaviour {
	Rigidbody ri;
	// Use this for initialization
	void Awake () {
		ri = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "rightTile") {
			
			Debug.Log ("r");
			ri.AddForce (Vector3.right * ri.mass*25000);
		}

		if (col.gameObject.tag == "leftTile") {
			ri.AddForce (Vector3.left * ri.mass*25000);
			Debug.Log ("l");
		}

		if (col.gameObject.tag == "frontTile") {
			ri.AddForce (Vector3.forward * ri.mass*25000);
			Debug.Log ("f");
		}

		if (col.gameObject.tag == "backTile") {
			ri.AddForce (Vector3.back * ri.mass*25000);
			Debug.Log ("b");
		}
	}
	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "tile")
			Debug.Log ("coll ");
	}
}
