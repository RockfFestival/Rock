using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayUserId : Photon.MonoBehaviour {
	private PhotonView pv = null;
    public static TextMesh tm;
    public GameObject gameObject;
    Text id1, id2, id3, id4;
    // Use this for initialization
	void Awake () {
		pv = GetComponent<PhotonView> ();
        //id1 = GameObject.Find("player1").GetComponent<Text>();
        //id2 = GameObject.Find("player2").GetComponent<Text>();
        //id3 = GameObject.Find("player3").GetComponent<Text>();
        //id4 = GameObject.Find("player4").GetComponent<Text>();

        //if (OnAuctionEventMrg.playerID == 1)
        //{
        //    gameObject = GameObject.Find("1Name");
        //    tm = gameObject.GetComponent<TextMesh>();
        //    tm.text = id1.text;
        //    Debug.Log("1");
        //}
        //else if (OnAuctionEventMrg.playerID == 2)
        //{
        //    gameObject = GameObject.Find("2Name");
        //    tm = gameObject.GetComponent<TextMesh>();
        //    tm.text = id2.text;
        //    Debug.Log("2");
        //}
        //else if (OnAuctionEventMrg.playerID == 3)
        //{
        //    gameObject = GameObject.Find("3Name");
        //    tm = gameObject.GetComponent<TextMesh>();
        //    tm.text = id3.text;
        //    Debug.Log("3");
        //}
        //else if (OnAuctionEventMrg.playerID == 4)
        //{
        //    gameObject = GameObject.Find("4Name");
        //    tm = gameObject.GetComponent<TextMesh>();
        //    tm.text = id4.text;
        //    Debug.Log("4");
        //}
    }

    //[PunRPC]
    //public void SendNickName2(PhotonMessageInfo info)
    //{
    //    SendNickName3();
    //}
    //void SendNickName2()
    //{
    //    SendNickName3( PhotonTargets.All, tm.text);
    //}
    //void SendNickName3()
    //{
    //    if (OnAuctionEventMrg.playerID == 1)
    //    {
    //        gameObject = GameObject.Find("1Name");
    //        tm = gameObject.GetComponent<TextMesh>();
    //        tm.text = RandomMatchMaker.userNickName;
    //        Debug.Log("1");
    //    }
    //    else if (OnAuctionEventMrg.playerID == 2)
    //    {
    //        gameObject = GameObject.Find("2Name");
    //        tm = gameObject.GetComponent<TextMesh>();
    //        tm.text = RandomMatchMaker.userNickName;
    //        Debug.Log("2");
    //    }
    //    else if (OnAuctionEventMrg.playerID == 3)
    //    {
    //        gameObject = GameObject.Find("3Name");
    //        tm = gameObject.GetComponent<TextMesh>();
    //        tm.text = RandomMatchMaker.userNickName;
    //        Debug.Log("3");
    //    }
    //    else if (OnAuctionEventMrg.playerID == 4)
    //    {
    //        gameObject = GameObject.Find("4Name");
    //        tm = gameObject.GetComponent<TextMesh>();
    //        tm.text = RandomMatchMaker.userNickName;
    //        Debug.Log("4");
    //    }
    //}
}
