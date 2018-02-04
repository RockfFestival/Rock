using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMgr : Photon.MonoBehaviour {
	public Camera main;
	public Canvas Exit_Login;
	public Canvas Exit_Exit;
	public Canvas Exit_Chat;
	public Text txtConnect;
	public Text txtMsg;

	private PhotonView pv;
	public InputField inputTxt;
	public List<string> chatList = new List<string> ();
	public Canvas Game_AuctionCanvas;
	private bool exit;

	public Text Gold;
	public GameObject startButton;
	// Use this for initialization
	void Start () {
		pv = GetComponent<PhotonView> ();
		PhotonNetwork.isMessageQueueRunning = true;
		inputTxt.text = "";
		//GetConnectPlayerCount ();
		startButton.SetActive(false);
	}
	void Update(){
        if (Input.GetKeyDown (KeyCode.Return)) {
			SendButton ();
		}
	}
	public void Join(){
		if (PhotonNetwork.player.ID == 1) {
			startButton.SetActive(true);
		} else {
			startButton.SetActive(false);
		}
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

		PhotonNetwork.LeaveRoom ();

	}
	void OnLeftRoom(){
		main.transform.position = new Vector3 (0.0f, 300.0f, 0.0f);
		main.transform.rotation = Quaternion.Euler (0, 0, 0);
		Exit_Login.enabled = true;
		Exit_Exit.enabled = false;
		Exit_Chat.enabled = false;
	}

	[PunRPC]
	public void SengMsg(string msg, PhotonMessageInfo info){
		/*if (exit == true) {
			switch (info.sender.ID) {
			case 1:
				Game_AuctionCanvas1.enabled = true;
				msg += "1";
				exit = false;
				break;
			case 2:
				Game_AuctionCanvas2.enabled = true;
				msg += "2";
				exit = false;
				break;
			case 3:
				Game_AuctionCanvas3.enabled = true;
				msg += "3";
				exit = false;
				break;
			case 4:
				Game_AuctionCanvas4.enabled = true;
				msg += "4";
				exit = false;
				break;
			}
		}
		if (msg.Contains ("open")) {
			
		}
		else if(msg.Contains("close")){
			switch (info.sender.ID) {
			case 1:
				Game_optionCanvas1.enabled = false;
				break;
			case 2:
				Game_optionCanvas2.enabled = false;
				break;
			case 3:
				Game_optionCanvas3.enabled = false;
				break;
			case 4:
				Game_optionCanvas4.enabled = false;
				break;
			}
		}*/
		//해시테이블 사용해서 데이터 저장-각 플레이어의 골드 출력
		PhotonPlayer[] p = PhotonNetwork.playerList;
		foreach (PhotonPlayer _p in p) {
			ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { _p.ID+"Gold",Gold.text } };
			_p.SetCustomProperties (hash);
		}

		Addchat (string.Format ("{0} : {1}", info.sender.NickName, msg));
	}
	public void SendButton(){
		string currTxt = inputTxt.text;
		Send (PhotonTargets.All, currTxt);
		inputTxt.text = string.Empty;
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
		PhotonPlayer[] p = PhotonNetwork.playerList;
		foreach (PhotonPlayer _p in p) {
			string gold = (string)_p.CustomProperties [_p.ID + "Gold"];
			Send (PhotonTargets.All, gold);
		}
	}
}
