using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RandomMatchMaker : Photon.PunBehaviour {
    public static string userNickName;

	public GameMgr mgr;
	public InputField userId;
	public InputField roomName;

	public GameObject scrollContents;
	public GameObject roomItem;
	public GameObject UIMap;

	public Camera gameCamera;
	public Canvas loginCanvas;
	public Canvas ExitCanvas;
	public Canvas ChatCanvas;
	public Canvas AuctionCanvas;
	public Canvas PlayTime;

    public Quaternion Second = Quaternion.identity;
    public Quaternion Third = Quaternion.identity;
    public Quaternion Forth = Quaternion.identity;
    
 

    // Use this for initialization
	void Awake () {
		if (!PhotonNetwork.connected) {
			PhotonNetwork.ConnectUsingSettings("0.1");
		
		}
		roomName.text = "ROOM_" + Random.Range (0, 999).ToString ("000");
		ExitCanvas.enabled = false;
		ChatCanvas.enabled = false;
		loginCanvas.enabled = true;
		PlayTime.enabled = false;
		AuctionCanvas.enabled = false;

	}

	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
		userId.text = GetUserId ();
    }
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room");
        PhotonNetwork.CreateRoom("MyRoom");
    }
	public override void OnJoinedRoom(){
		mgr.GetConnectPlayerCount ();
		mgr.Join ();
        userNickName = userId.text;


		loginCanvas.enabled = false;
		ExitCanvas.enabled = true;
		ChatCanvas.enabled = true;
        // 시작화면에 있는 돌맹이랑 맵 삭제
        GameObject[] TS = GameObject.FindGameObjectsWithTag("Trash_Stone");
        for (int i = 0; i < 61; i++)
        {
            Destroy(TS[i]);
        }
        Destroy(UIMap);
       
	}

	string GetUserId(){
		string userId = PlayerPrefs.GetString ("USER_ID");
		if(string.IsNullOrEmpty(userId)){
			userId="USER_" + Random.Range(0,999).ToString("0000");
		}
		return userId;
			
	}
	public void OnClickCreateRoom(){


		string _roomName = roomName.text;
		if (string.IsNullOrEmpty (roomName.text)) {
			_roomName = "Room_" + Random.Range (0, 999).ToString ("000");
		}
		PhotonNetwork.player.NickName = userId.text;
		PlayerPrefs.SetString ("USER_ID", userId.text);
        userNickName = userId.text;

		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.IsOpen = true;
		roomOptions.IsVisible = true;
		roomOptions.MaxPlayers = 4;

		PhotonNetwork.CreateRoom (_roomName, roomOptions, TypedLobby.Default);

	}
	public override void OnPhotonCreateRoomFailed(object[] code){


	}

	public override void OnReceivedRoomListUpdate(){

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ROOM_ITEM")) {
			Destroy (obj);
		}

		scrollContents.GetComponent<RectTransform> ().sizeDelta = Vector2.zero;
		foreach (RoomInfo _room in PhotonNetwork.GetRoomList()) {
			if (_room.IsOpen == true) {
				
				GameObject room = (GameObject)Instantiate (roomItem);
				room.transform.SetParent (scrollContents.transform, false);
		

				RoomData roomData = room.GetComponent<RoomData> ();
				roomData.roomName = _room.Name;
				roomData.connectPlayer = _room.PlayerCount;
				roomData.maxPlayers = _room.MaxPlayers;

				roomData.DispRoomData ();
				roomData.GetComponent<UnityEngine.UI.Button> ().onClick.AddListener (delegate {
					OnClickRoomItem (roomData.roomName);
					Debug.Log ("Room Click" + room.name);
				});
			}
		}

	}
	void OnClickRoomItem(string roomName){
		PhotonNetwork.player.NickName = userId.text;
		PlayerPrefs.SetString ("USER_ID", userId.text);
        userNickName = userId.text;
		PhotonNetwork.JoinRoom (roomName);
	}
}
