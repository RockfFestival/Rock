using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMgr : MonoBehaviour {
	public Camera login;
	public Camera main;
	public Text txtConnect;
	// Use this for initialization
	void Awake () {
		PhotonNetwork.isMessageQueueRunning = true;

		//GetConnectPlayerCount ();
	
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
		PhotonNetwork.LeaveRoom ();
	}
	void OnLeftRoom(){
		login.enabled = true;
		main.enabled = false;

	}
}
