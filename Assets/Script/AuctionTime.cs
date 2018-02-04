using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuctionTime : MonoBehaviour {

	public Text TimeText;
	private PhotonView pv;

    float timeCount;

    // Use this for initialization
    void Start()
    {
		pv = GetComponent<PhotonView> ();
        timeCount = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
     if(timeCount != 0)
        {
            timeCount -= Time.deltaTime;

            if(timeCount <= 0)
            {
                timeCount = 0;
            }
        }

        int t = Mathf.FloorToInt(timeCount);
		printTime (t);
    }
	[PunRPC]
	public void sendTime(int msg, PhotonMessageInfo info){
		changeTime (msg);
	}
	public void printTime(int ta){
		Send (PhotonTargets.All, ta);
	}
	void Send(PhotonTargets target, int msg){
		pv.RPC ("sendTime", target, msg);
	}
	public void changeTime(int msg){
		TimeText.text = msg.ToString ();
	}
}
