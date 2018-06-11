using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class GameMgr : Photon.MonoBehaviour {
	public Camera main;
	public Canvas Exit_Login;
	public Canvas Exit_Exit;
	public Canvas Exit_Chat;
	public Canvas Exit_Item;
	public Canvas Item_openCanvas;
    public Canvas AuctionCanvas;
	public Canvas infoCanvas;
	public GameObject panel1;

	public Text txtConnect;
	public Text txtMsg;
	public List<string> chatList = new List<string> ();
	private PhotonView pv;
	public InputField inputTxt;
	public Text Money;
	public Canvas Game_AuctionCanvas;
	private bool exit;
	public int save = -1;
	public static int[] winner = new int[4];
	public Text Gold;
	public GameObject startButton;
	public Text fStoneT;
	public Text startPlayerCount;
	// Use this for initialization
	Text pmoney1,pmoney2,pmoney3,pmoney4;
	//돌 정보 저장 구조체 
	public AuctionTime auctionTime;


	void Awake () {
		panel1.SetActive (false);
		pv = GetComponent<PhotonView> ();
        AuctionCanvas = GameObject.Find("AuctionCanvas").GetComponent<Canvas>();
		PhotonNetwork.isMessageQueueRunning = true;
		inputTxt.text = "";
		//GetConnectPlayerCount ();
		startButton.SetActive(false);
		Exit_Item.enabled = false;
		Item_openCanvas.enabled = false;
        for (int i = 0; i < 4; i++){
            winner[i] = 0;
        }
		pmoney1 = GameObject.Find ("money1p").GetComponent<Text> ();
		pmoney2 = GameObject.Find ("money2p").GetComponent<Text> ();
		pmoney3 = GameObject.Find ("money3p").GetComponent<Text> ();
		pmoney4 = GameObject.Find ("money4p").GetComponent<Text> ();
	}
	void Update(){
        if (Input.GetKeyDown (KeyCode.Return)) {
			SendButton ();
		}
	}
	public void Item_Close(){
		fStoneT.text = "합성";
		InvenImgClick.fStone = false;
		Exit_Item.enabled = false;
		Item_openCanvas.enabled = true;
		infoCanvas.enabled = false;
	}
	public void InfoClose(){
		fStoneT.text = "합성";
		InvenImgClick.fStone = false;
		infoCanvas.enabled = false;

	}
	public void Item_Open(){
		Exit_Item.enabled = true;
		Item_openCanvas.enabled = false;
		auctionTime.Item_print ();
	}

	public void Join(){
		if (PhotonNetwork.player.ID == 1) {
			startButton.SetActive(true);
		} else {
			startButton.SetActive(false);
		}

		Item_openCanvas.enabled = true;
		Game_AuctionCanvas.enabled = true;
		string msg = " CONNECT";
		txtMsg.text = string.Empty;
		pv.RPC ("SengMsg", PhotonTargets.All, msg);
		inputTxt.caretWidth = 50;
	}

	public void GetConnectPlayerCount(){
		PhotonNetwork.isMessageQueueRunning = true;
		Room currRoom = PhotonNetwork.room;
		txtConnect.text = currRoom.PlayerCount.ToString () + "/"+ currRoom.MaxPlayers.ToString();
		startPlayerCount.text = "현재인원 : " + currRoom.PlayerCount.ToString () + "/"+ currRoom.MaxPlayers.ToString();
	}
	void OnPhotonPlayerConnected(PhotonPlayer Player){
		GetConnectPlayerCount();
	}
	void OnPhotonPlayerDisconnected(PhotonPlayer outPlayer){
		GetConnectPlayerCount ();
	}
	void OnClickExitRoom(){
		
		string msg = " DISCONNECT";
		pv.RPC ("SengMsg", PhotonTargets.All, msg);
		ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { "state","null" } };
		PhotonNetwork.player.SetCustomProperties (hash);
		PhotonNetwork.LeaveRoom ();

	}
	void OnLeftRoom(){

		main.transform.position = new Vector3 (0.0f, 300.0f, 0.0f);
		main.transform.rotation = Quaternion.Euler (0, 0, 0);
		Exit_Login.enabled = true;
		Exit_Exit.enabled = false;
		Exit_Chat.enabled = false;
        AuctionCanvas.enabled = false;

		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	[PunRPC]
	public void SengMsg(string msg, PhotonMessageInfo info){

		Addchat (string.Format ("{0} : {1}", info.sender.NickName, msg));
	}
	public void SendButton(){
		string currTxt = inputTxt.text;
		if (currTxt == "") {
			inputTxt.ActivateInputField ();
		} else {
			Send (PhotonTargets.All, currTxt);
			inputTxt.text = string.Empty;
		}
	}
	void Send(PhotonTargets target, string msg){
		pv.RPC ("SengMsg", target, msg);
	}
	public void Addchat(string msg){
		string chat = txtMsg.text;
		chat += string.Format ("\n{0}", msg);
		txtMsg.text = chat;
		chatList.Add (msg);



	}

	public void Print(){
		save = 0;
		winner [0] = 0;
		winner [1] = 0;
		winner [2] = 0;
		winner [3] = 0;
		Text t1, t2, t3,t4;
		t1 = GameObject.Find ("t1").GetComponent<Text>();
		t2 = GameObject.Find ("t2").GetComponent<Text>();
		t3 = GameObject.Find ("t3").GetComponent<Text>();
		t4 = GameObject.Find ("t4").GetComponent<Text>();

		if (save <= int.Parse (t1.text)) {
			save = int.Parse (t1.text);
			winner[0] = 1;
		}
		if (PhotonNetwork.room.PlayerCount >= 2) {
			
			if (save < int.Parse (t2.text)) {
				save = int.Parse (t2.text);
				winner [0] = 2;
			} else if (save == int.Parse (t2.text)) {
				winner [1] = 2;
			}
		}
		if (PhotonNetwork.room.PlayerCount >= 3) {
			
			if (save < int.Parse (t3.text)) {
				save = int.Parse (t3.text);
				winner [0] = 3;
				winner [1] = 0;
			} else if (save == int.Parse (t3.text)) {
				for (int i = 0; i < 4; i++) {
					if (winner [i] == 0) {
						winner [i] = 3;
						break;
					}
				}
			}
		}
		if (PhotonNetwork.room.PlayerCount >= 4) {
			
			if (save < int.Parse (t4.text)) {
				save = int.Parse (t4.text);
				winner [0] = 4;
				winner [1] = 0;
				winner [2] = 0;
			} else if (save == int.Parse (t4.text)) {
				for (int i = 0; i < 4; i++) {
					if (winner [i] == 0) {
						winner [i] = 4;
						break;
					}
				}
			}
		}
		if ((string)PhotonNetwork.player.CustomProperties ["state"] == "start") {
			asdf (winner, save);

		}

		//save = -1;

		//string re = winner.ToString () + ";" + save.ToString ();
		//return string.Format("{0};{1}",winner,save);
	}


	//각자의 돈비교 동일 경우면 앞 플레이어가 이김
	[PunRPC]
	public void compareMoney(int[] win, int save){
		compute(win, save);
	}
	public void asdf(int[] win, int save){
		Test (PhotonTargets.All,win,save);
	}
	void Test(PhotonTargets target, int[] win, int save){
		pv.RPC ("compareMoney", target,win,save);
	}
	public void compute(int[] win, int save){
		int nowMoney = int.Parse (Money.text);
		int data = nowMoney - save;
		for (int i = 0; i < 4; i++) {
			if (PhotonNetwork.player.ID==win[i]) {
				checkmoney2 (data, win[i]);
				SendWinner (data,win[i]);
				break;
			}
		}
		Text t1, t2, t3,t4;
		t1 = GameObject.Find ("t1").GetComponent<Text>();
		t2 = GameObject.Find ("t2").GetComponent<Text>();
		t3 = GameObject.Find ("t3").GetComponent<Text>();
		t4 = GameObject.Find ("t4").GetComponent<Text>();
		t1.text = "0";
		t2.text = "0";
		t3.text = "0";
		t4.text = "0";
		save = 0;
	}

	[PunRPC]
	public void checkmoney1(int m, int win, PhotonMessageInfo info){
		checkmoney4 (m,win);
	}
	public void checkmoney2(int m, int win){
		checkmoney3 (PhotonTargets.All ,m,win);
	}
	void checkmoney3(PhotonTargets target, int m, int win){
		pv.RPC ("checkmoney1", target, m,win);
	}
	public void checkmoney4(int m,int win){
		if (GameObject.Find (win.ToString ()) != null) {
			Money.text = m.ToString ();
		}

	}

	//승자 RPC통신
	[PunRPC]
	public void SendWin(int data,int msg, PhotonMessageInfo info){
		Addwinner (data,msg);
	}
	public void SendWinner(int data,int win){
		Sendww (PhotonTargets.All,data, win);
	}
	void Sendww(PhotonTargets target,int data, int msg){
		pv.RPC ("SendWin", target,data, msg);
	}
	public void Addwinner(int data,int msg){
		string chat = txtMsg.text;
		chat += string.Format ("\n경매 승리 : {0}", msg);
		txtMsg.text = chat;
		chatList.Add (msg.ToString());

		switch (msg) {
		case 1:
			pmoney1.text = data.ToString ();
			break;
		case 2:
			pmoney2.text = data.ToString ();
			break;
		case 3:
			pmoney3.text = data.ToString ();
			break;
		case 4:
			pmoney4.text = data.ToString ();
			break;
		}


	}

}
