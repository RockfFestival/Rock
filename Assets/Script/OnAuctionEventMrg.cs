using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnAuctionEventMrg : Photon.MonoBehaviour {
	private PhotonView pv;
    public static bool isStart = false;
    public static int playerID = 0;
	public Transform playerName;
	public GameObject player;
	public GameObject pane;
	public GameObject offPane;
	// Use this for initialization
	public Quaternion Second = Quaternion.identity;
	public Quaternion Third = Quaternion.identity;
	public Quaternion Forth = Quaternion.identity;
	void Awake () {
		pv = GetComponent<PhotonView> ();
		PhotonNetwork.isMessageQueueRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick_StartBtn()
    {//스타트버튼누르면 상태를 시작으로 변경
		pv = GetComponent<PhotonView> ();
        isStart = true;
		PhotonNetwork.isMessageQueueRunning = true;
        //AEM.SetActive(true);
		PhotonNetwork.room.IsOpen = false;
		PhotonNetwork.room.IsVisible = false;
		CreateStone1 (0);


		ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { "state","start" } };
		PhotonNetwork.player.SetCustomProperties (hash);

    }

	[PunRPC]
	public void idSave3(int i,PhotonMessageInfo info){
		idSave4 (i);
	}
	public void idSave1(int i){
		idSave2 (PhotonTargets.All,i);
	}
	void idSave2(PhotonTargets target,int i){
		pv.RPC ("idSave3", target,i);

	}
	public void idSave4(int id){
		Text id1, id2, id3, id4;
        TextMesh tm1, tm2, tm3, tm4;
		id1 = GameObject.Find ("player1").GetComponent<Text>();
		id2 = GameObject.Find ("player2").GetComponent<Text>();
		id3 = GameObject.Find ("player3").GetComponent<Text>();
		id4 = GameObject.Find ("player4").GetComponent<Text>();

        tm1 = GameObject.Find("1Name").GetComponent<TextMesh>();
        tm2 = GameObject.Find("2Name").GetComponent<TextMesh>();
        tm3 = GameObject.Find("3Name").GetComponent<TextMesh>();
        tm4 = GameObject.Find("4Name").GetComponent<TextMesh>();


        GameObject[] st = GameObject.FindGameObjectsWithTag ("Stone");

		for (int i = 0; i < st.Length; i++) {
			if (st [i].GetComponent<PhotonView> ().owner.ID == 1) {
				id1.text = st [i].GetComponent<PhotonView> ().owner.NickName;
				tm1.text = st [i].GetComponent<PhotonView> ().owner.NickName;
				
			} else if (st [i].GetComponent<PhotonView> ().owner.ID == 2) {
				id2.text = st [i].GetComponent<PhotonView> ().owner.NickName;
				tm2.text = st [i].GetComponent<PhotonView> ().owner.NickName;

			} else if (st [i].GetComponent<PhotonView> ().owner.ID == 3) {
				id3.text = st [i].GetComponent<PhotonView> ().owner.NickName;
				tm3.text = st [i].GetComponent<PhotonView> ().owner.NickName;
			} else if (st [i].GetComponent<PhotonView> ().owner.ID == 4) {
				id4.text = st [i].GetComponent<PhotonView> ().owner.NickName;
				tm4.text = st [i].GetComponent<PhotonView> ().owner.NickName;
			}
		}
		isStart = true;

	}



	[PunRPC]
	public void CreateStone3(int i,PhotonMessageInfo info){
		CreateStone4 (i);
	}
	public void CreateStone1(int i){
		CreateStone2 (PhotonTargets.All,i);
	}
	void CreateStone2(PhotonTargets target,int i){
		pv.RPC ("CreateStone3", target,i);
	}
	public void CreateStone4(int id){
		pane.SetActive (true);
		offPane.SetActive (false);
		id=PhotonNetwork.player.ID;
		playerID = id;
		Second.eulerAngles = new Vector3(0, 180 ,0);
		Third.eulerAngles = new Vector3(0, 90, 0);
		Forth.eulerAngles = new Vector3(0, 270, 0);
		GameObject spawn;

		if (id == 1) {
			spawn = GameObject.Find ("spawn1");
			PhotonNetwork.Instantiate ("FracturedStone",spawn.transform.position, Quaternion.identity, 0).transform.name = "1";
		} else if (id ==2) {
			spawn = GameObject.Find ("spawn2");
			PhotonNetwork.Instantiate ("FracturedStone", spawn.transform.position,Second, 0).transform.name = "2";
		}
		else if (id ==3) {
			spawn = GameObject.Find ("spawn3");
			PhotonNetwork.Instantiate ("FracturedStone",spawn.transform.position,Third, 0).transform.name = "3";

		}
		else if (id ==4) {
			spawn = GameObject.Find ("spawn4");
			PhotonNetwork.Instantiate ("FracturedStone", spawn.transform.position,Forth, 0).transform.name = "4";
		}
		idSave1 (0);
	}
}
