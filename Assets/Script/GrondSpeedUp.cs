using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrondSpeedUp : MonoBehaviour {
    public static int OnGroundFlag = 0;

	// Use this for initialization
	void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
		


	}


    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Stone") {
			
			Debug.Log ("바닥하고부딪힘");
			OnGroundFlag = 1;  
		}
    }

    /*private void 
    {
        Debug.Log("바닥하고부딪힘");
        if (other.tag == "Stone")
        {
            Debug.Log("바닥하고부딪힘");
            // AddForce점 ㅎ
            OnGroundFlag = 1;
            //Debug.Log(OnGroundFlag);
        }
    }
    */


}
