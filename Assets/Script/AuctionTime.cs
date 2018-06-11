using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AuctionTime : Photon.MonoBehaviour {
	public GameMgr gm;
	public GameObject AuctionItemImage;
	public GameObject startButton;

	public Canvas AuctionCanvas;
	public Canvas PlayTime;
	public Canvas Time_Auction;

	public Text Money;//소유돈
	public Text TimeText;
	public Text Gold;
	public Text AuctionInfoItemText;
	public Text txtMsg;
	public Text gameTimeText;

	public List<string> chatList = new List<string> ();

	public static string gameState;
	public static int propelTime = 100;
	public static int have_stone = 1;
	public Image item_image1;
	public Image item_image2;
	public Image item_image3;
	public Image item_image4;
	public Image item_image5;
	public static StoneInfo[] stoneinfo;
	public static StoneInfo[] playerStone = new StoneInfo[5];
	public string gameStateTimer;
	Text pmoney1,pmoney2,pmoney3,pmoney4;
	bool game_start = false;
	public float timeCount;
	public GameObject Fence1, Fence2, Fence3, Fence4;
	private PhotonView pv;
	private bool print = true;
	int rand;
	bool flag = true;
	bool saveFlag = true;
	Quaternion Second = Quaternion.identity;
	Quaternion Third = Quaternion.identity;
	Quaternion Forth = Quaternion.identity;
	public static int roundCount;
	public Camera DataCamera;
	bool start = false;
	int random;
	string sq1="0",sq2="0",sq3="0",sq4="0";
	Camera mainC;
	[Serializable]
	public struct StoneInfo{
		public bool check;
		public int mass;
		public int Hp;
		public int scale;
		public string imageString;
		public string stoneTexture;
		public bool firstStone;
		public string StoneName;
		public StoneInfo(bool check,int mass, int Hp, int scale,string imageString,string text,bool firstStone,string name){
			this.check = check;
			this.mass = mass;
			this.Hp = Hp;
			this.scale = scale;
			this.imageString = imageString;
			this.stoneTexture = text;
			this.firstStone = firstStone;
			this.StoneName = name;
		}
	};

	// Use this for initialization
	void Awake()
	{
		pmoney1 = GameObject.Find ("money1p").GetComponent<Text> ();
		pmoney2 = GameObject.Find ("money2p").GetComponent<Text> ();
		pmoney3 = GameObject.Find ("money3p").GetComponent<Text> ();
		pmoney4 = GameObject.Find ("money4p").GetComponent<Text> ();

		mainC = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		AuctionInfoItemText.enabled = false;
		gameState = "";
		print = true;
		pv = GetComponent<PhotonView> ();
		timeCount = 20.0f;
		AuctionTime.have_stone = 1;
		AuctionTime.roundCount = 1;
		AuctionTime.propelTime = 100;
		AuctionCanvas = GameObject.Find("AuctionCanvas").GetComponent<Canvas>();
		PhotonNetwork.isMessageQueueRunning = true;
		stoneinfo = new StoneInfo[] {
			new StoneInfo(true,3,5,33,"StoneImage/default","StoneMaterial/default",true,"시멘트"),
			new StoneInfo(true,4,6,34,"StoneImage/blue","StoneMaterial/blue",false,"구름돌"),
			new StoneInfo(true,5,6,34,"StoneImage/chocolate","StoneMaterial/chocolate",false,"초코릿"),
			new StoneInfo(true,5,6,34,"StoneImage/coffe","StoneMaterial/coffe",false,"커피"),
			new StoneInfo(true,6,7,35,"StoneImage/green","StoneMaterial/green",false,"옥석"),

			new StoneInfo(true,7,11,35,"StoneImage/marron","StoneMaterial/marron",false,"마로니에"),
			new StoneInfo(true,8,12,35,"StoneImage/rio","StoneMaterial/rio",false,"리오"),
			new StoneInfo(true,8,12,36,"StoneImage/white","StoneMaterial/white",false,"자갈"),
			new StoneInfo(true,9,13,41,"StoneImage/floortile","StoneMaterial/floortile",false,"논밭"),
			new StoneInfo(true,10,14,36,"StoneImage/glass","StoneMaterial/glass",false,"스텐글래스"),

			new StoneInfo(true,11,15,45,"StoneImage/grass","StoneMaterial/grass",false,"잔디"),
			new StoneInfo(true,12,16,37,"StoneImage/mudrocky","StoneMaterial/mudrocky",false,"진흙"),
			new StoneInfo(true,13,20,38,"StoneImage/pavement_1","StoneMaterial/pavement_1",false,"벽돌"),
			new StoneInfo(true,13,17,38,"StoneImage/pavement_2","StoneMaterial/pavement_2",false,"블럭"),
			new StoneInfo(true,15,18,38,"StoneImage/splash_2","StoneMaterial/splash_1",false,"도트"),

			new StoneInfo(true,16,21,38,"StoneImage/splash_2","StoneMaterial/splash_2",false,"안개"),
			new StoneInfo(true,17,24,38,"StoneImage/DarkBlueOpacityMaterial","StoneMaterial/DarkBlueOpacityMaterial",false,"사파이어"),
			new StoneInfo(true,18,26,38,"StoneImage/DarkPurpleOpacityMaterial","StoneMaterial/DarkPurpleOpacityMaterial",false,"자수정"),
			new StoneInfo(true,18,26,38,"StoneImage/DarkRedOpacityMaterial","StoneMaterial/DarkRedOpacityMaterial",false,"루비"),
			new StoneInfo(true,20,29,43,"StoneImage/Flare50mm","StoneMaterial/Flare50mm",false,"플레어"),

			new StoneInfo(true,25,30,38,"StoneImage/LightGreenOpacityMaterial","StoneMaterial/LightGreenOpacityMaterial",false,"에메랄드"),
			new StoneInfo(true,26,34,38,"StoneImage/LightGrayOpacityMaterial","StoneMaterial/LightGreyOpacityMaterial",false,"다이아몬드"),
			new StoneInfo(true,28,37,50,"StoneImage/Orange","StoneMaterial/Orange",false,"시트린"),
			new StoneInfo(true,28,37,38,"StoneImage/SkyCarLightGlows","StoneMaterial/SkyCarLightGlows",false,"불꽃"),
			new StoneInfo(true,30,40,38,"StoneImage/YellowOpacityMaterial","StoneMaterial/YellowOpacityMaterial",false,"호박")

		};
		playerStone [0] = new StoneInfo (true,3, 5, 33,"StoneImage/default","StoneMaterial/default",true,"시멘트");
		playerStone [1].imageString = "StoneImage/invenDefault";
		playerStone [2].imageString = "StoneImage/invenDefault";
		playerStone [3].imageString = "StoneImage/invenDefault";
		playerStone [4].imageString = "StoneImage/invenDefault";

	}


	public void Item_print(){
		for (int i = 0; i < have_stone; i++) {
			switch (i) {
			case 0:
				item_image1.sprite = Resources.Load<Sprite>(playerStone[0].imageString) as Sprite;
				break;
			case 1:
				item_image2.sprite = Resources.Load<Sprite>(playerStone[1].imageString) as Sprite;
				break;
			case 2:
				item_image3.sprite = Resources.Load<Sprite>(playerStone[2].imageString) as Sprite;
				break;
			case 3:
				item_image4.sprite = Resources.Load<Sprite>(playerStone[3].imageString) as Sprite;
				break;
			case 4:
				item_image5.sprite = Resources.Load<Sprite>(playerStone[4].imageString) as Sprite;
				break;
			}
		}
	}
	// Update is called once per frame
	void Update()
	{
		if (start == true) {

			if (Input.GetKeyDown (KeyCode.Tab)) {
				if (DataCamera.enabled == false) {
					mainC.enabled = false;
					DataCamera.enabled = true;
					AuctionCanvas.enabled = false;
				} else {
					if(gameStateTimer != "ready"&&gameStateTimer != "game"&&gameStateTimer != "end")
						AuctionCanvas.enabled = true;
					mainC.enabled = true;
					DataCamera.enabled = false;
				}
			}
		}
		if ((string)PhotonNetwork.player.CustomProperties ["state"] == "start") {
			gameStateTimer = "auction";
			startButton.SetActive (false);

			if(AuctionTime.roundCount==1)
				random = UnityEngine.Random.Range (1, 6);
			else if(AuctionTime.roundCount==2)
				random = UnityEngine.Random.Range (6, 11);
			else if(AuctionTime.roundCount==3)
				random = UnityEngine.Random.Range (11, 16);
			else if(AuctionTime.roundCount==4)
				random = UnityEngine.Random.Range (16, 21);
			else if(AuctionTime.roundCount==5)
				random = UnityEngine.Random.Range (21, 26);
				
			if (timeCount != 0) {
				timeCount -= Time.deltaTime;

				if (timeCount <= 0) {
					timeCount = 0;
					if (print == true) {
						//endTime ();
						print = false;
						gm.Print ();
						SendItem (rand, GameMgr.winner);
						timeCount = 15;
						gameStateTimer = "ready";
						ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { "state","ready" } };
						PhotonNetwork.player.SetCustomProperties (hash);
					}
					//********나중에 쓸거임*********
					//AuctionCanvas.enabled = false;
					//******************************
					int t = Mathf.FloorToInt (timeCount);
					printTime (t, random, gameStateTimer);
				} else {
					int t = Mathf.FloorToInt (timeCount);
					printTime (t, random, gameStateTimer);
				}

			}
			//0초 되면 함수 실행

		}else if ((string)PhotonNetwork.player.CustomProperties ["state"] == "ready") {
			PlayTime.enabled = true;
			print = true;
			if (timeCount != 0) {
				timeCount -= Time.deltaTime;

				if (timeCount <= 0) {
					timeCount = 0;
					if (print == true) {
						//endTime ();
						gameStateTimer = "game";
						print = false;
						//game state change
						timeCount = 40;
						ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { "state","game" } };
						PhotonNetwork.player.SetCustomProperties (hash);
					}
					//********나중에 쓸거임*********
					//AuctionCanvas.enabled = false;
					//******************************
					int t = Mathf.FloorToInt (timeCount);

					printgameTime (t, gameStateTimer);
				} else {
					int t = Mathf.FloorToInt (timeCount);
					printgameTime (t, gameStateTimer);
				}
			}
		}  else if ((string)PhotonNetwork.player.CustomProperties ["state"] == "game") {
			PlayTime.enabled = true;
			print = true;
			if (timeCount != 0) {
				timeCount -= Time.deltaTime;

				if (timeCount <= 0) {
					timeCount = 0;
					if (print == true) {
						//endTime ();
						gameStateTimer = "end";
						print = false;
						deltrash1 (0);
						//game state change
						ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { "state","end" } };
						PhotonNetwork.player.SetCustomProperties (hash);
					}
					Text save1, save2, save3, save4;
					save1 = GameObject.Find ("save1").GetComponent<Text> ();
					save2 = GameObject.Find ("save2").GetComponent<Text> ();
					save3 = GameObject.Find ("save3").GetComponent<Text> ();
					save4 = GameObject.Find ("save4").GetComponent<Text> ();
					GameObject[] delstone = GameObject.FindGameObjectsWithTag ("Stone");
					for (int i = 0; i < delstone.Length; i++) {
						if (delstone [i].GetComponent<PhotonView> ().owner.ID == 1)
							sq1 = (int.Parse (save1.text) + 1).ToString ();
						if (delstone [i].GetComponent<PhotonView> ().owner.ID == 2)
							sq2 = (int.Parse (save2.text) + 1).ToString ();
						if (delstone [i].GetComponent<PhotonView> ().owner.ID == 3)
							sq3 = (int.Parse (save3.text) + 1).ToString ();
						if (delstone [i].GetComponent<PhotonView> ().owner.ID == 4)
							sq4 = (int.Parse (save4.text) + 1).ToString ();
					}
					//********나중에 쓸거임*********
					//AuctionCanvas.enabled = false;
					//******************************
					dele1(0);
					int t = Mathf.FloorToInt (timeCount);
					printendTime (t, gameStateTimer,sq1,sq2,sq3,sq4);
				} else {
					int t = Mathf.FloorToInt (timeCount);
					printgameTime (t, gameStateTimer);
				}
			}
		} else if ((string)PhotonNetwork.player.CustomProperties ["state"] == "end")  {
			/*
			GameObject[] stone = GameObject.FindGameObjectsWithTag ("Stone");
			for (int i = 0; i < stone.Length; i++) {
				Destroy (stone [i]);
			}*/
		}
	}
	[PunRPC]
	public void dele2(int a, PhotonMessageInfo info){

		dele4 (a);
	}
	public void dele1(int a){
		dele3 (PhotonTargets.All,a);
	}
	void dele3(PhotonTargets target, int a){
		pv.RPC ("dele2", target,a);
	}

	public void dele4(int a){
		GameObject[] delstone = GameObject.FindGameObjectsWithTag ("Stone");
		for (int i = 0; i < delstone.Length; i++)
			Destroy (delstone [i]);
	}


	//승자 인벤토리에 아이템저장

	[PunRPC]
	public void saveIn(int ran,int[] winner, PhotonMessageInfo info){

		saveItem (ran,winner);
	}
	public void SendItem(int ran,int[] winner){
		SendIt (PhotonTargets.All,ran,winner);
	}
	void SendIt(PhotonTargets target, int ran,int[] winner){
		pv.RPC ("saveIn", target, ran, winner);
	}

	public void saveItem(int ran,int[] winner){
		for (int i = 0; i < 4; i++) {
			if (PhotonNetwork.player.ID == winner[i]) {
				playerStone [have_stone] = stoneinfo [ran - 1];
				have_stone++;
			}
		}
		Item_print ();
		Gold.text = "0";
		/*
		if (PhotonNetwork.player.ID == 1) {
			pmoney1.text = Money.text;
			Debug.Log (Money.text);
		}
		if (PhotonNetwork.player.ID == 2) {
			pmoney2.text = Money.text;
		}
		if (PhotonNetwork.player.ID == 3) {
			pmoney3.text = Money.text;
		}
		if (PhotonNetwork.player.ID == 4) {
			pmoney4.text = Money.text;
		}*/
		AuctionCanvas.enabled = false;
		gameStateTimer = "ready";
	}
	//game timer
	[PunRPC]
	public void sendgameTime(int msg,string state, PhotonMessageInfo info){
		changegameTime (msg,state);
	}
	public void printgameTime(int ta,string state){
		Sendgame (PhotonTargets.All, ta,state);
	}
	void Sendgame(PhotonTargets target, int msg,string state){
		pv.RPC ("sendgameTime", target, msg,state);
	}
	public void changegameTime(int msg,string state){
		PlayTime.enabled = true;
		Fence1.SetActive (false);
		Fence2.SetActive (false);
		Fence3.SetActive (false);
		Fence4.SetActive (false);

		gameTimeText.text = "Round " + AuctionTime.roundCount.ToString() + " : " +msg.ToString ();
		if (state == "game") {
			propelTime = 0;
			AuctionTime.gameState = "game";
		}
	}
	[PunRPC]
	public void deltrash2(int msg, PhotonMessageInfo info){
		deltrash4 (msg);
	}
	public void deltrash1(int ta){
		deltrash3 (PhotonTargets.All, ta);
	}
	void deltrash3(PhotonTargets target, int msg){
		pv.RPC ("deltrash2", target, msg);
	}
	public void deltrash4(int msg){
		GameObject[] trashstone = GameObject.FindGameObjectsWithTag ("Trash_Stone");
		for (int i = 0; i < trashstone.Length; i++)
			Destroy (trashstone [i]);
	}

	[PunRPC]
	public void sendendTime(int msg,string state,string s1,string s2, string s3, string s4, PhotonMessageInfo info){
		changeendTime (msg,state,s1,s2,s3,s4);
	}
	public void printendTime(int ta,string state,string s1,string s2, string s3, string s4){
		Sendendgame (PhotonTargets.All, ta,state,s1,s2,s3,s4);
	}
	void Sendendgame(PhotonTargets target, int msg,string state,string s1,string s2, string s3, string s4){
		pv.RPC ("sendendTime", target, msg,state,s1,s2,s3,s4);
	}
	public void changeendTime(int msg,string state,string s1,string s2, string s3, string s4){

		AuctionInfoItemText.enabled = false;
		AuctionItemImage.SetActive (true);
		propelTime = 1;
		PlayTime.enabled = false;
		AuctionCanvas.enabled = true;
		print = true;
		Text save1, save2, save3, save4;
		save1 = GameObject.Find ("save1").GetComponent<Text> ();
		save2 = GameObject.Find ("save2").GetComponent<Text> ();
		save3 = GameObject.Find ("save3").GetComponent<Text> ();
		save4 = GameObject.Find ("save4").GetComponent<Text> ();
		save1.text = s1;
		save2.text = s2;
		save3.text = s3;
		save4.text = s4;

		Fence1.SetActive (true);
		Fence2.SetActive (true);
		Fence3.SetActive (true);
		Fence4.SetActive (true);

		if (AuctionTime.roundCount <5) {
			AuctionTime.roundCount++;
			Second.eulerAngles = new Vector3 (0, 180, 0);
			Third.eulerAngles = new Vector3 (0, 90, 0);
			Forth.eulerAngles = new Vector3 (0, 270, 0);
			GameObject spawn;


			if (PhotonNetwork.player.ID == 1) {
				spawn = GameObject.Find ("spawn1");
				PhotonNetwork.Instantiate ("FracturedStone", spawn.transform.position, Quaternion.identity, 0).transform.name = "1";
				Money.text = (int.Parse (Money.text) + 10 + int.Parse (GameObject.Find ("k1").GetComponent<Text> ().text) * 10).ToString ();
				Rigidbody a = GameObject.Find ("1").GetComponent<Rigidbody> ();
				a.velocity = Vector3.zero;
				a.angularVelocity = Vector3.zero;
			} else if (PhotonNetwork.player.ID == 2) {
				spawn = GameObject.Find ("spawn2");
				PhotonNetwork.Instantiate ("FracturedStone", spawn.transform.position, Second, 0).transform.name = "2";
				Money.text = (int.Parse (Money.text) + 10 + int.Parse (GameObject.Find ("k2").GetComponent<Text> ().text) * 10).ToString ();
				Rigidbody a = GameObject.Find ("2").GetComponent<Rigidbody> ();
				a.velocity = Vector3.zero;
				a.angularVelocity = Vector3.zero;
			} else if (PhotonNetwork.player.ID == 3) {
				spawn = GameObject.Find ("spawn3");
				PhotonNetwork.Instantiate ("FracturedStone", spawn.transform.position, Third, 0).transform.name = "3";
				Money.text = (int.Parse (Money.text) + 10 + int.Parse (GameObject.Find ("k3").GetComponent<Text> ().text) * 10).ToString ();
				Rigidbody a = GameObject.Find ("3").GetComponent<Rigidbody> ();
				a.velocity = Vector3.zero;
				a.angularVelocity = Vector3.zero;
			} else if (PhotonNetwork.player.ID == 4) {
				spawn = GameObject.Find ("spawn4");
				PhotonNetwork.Instantiate ("FracturedStone", spawn.transform.position, Forth, 0).transform.name = "4";
				Money.text = (int.Parse (Money.text) + 10 + int.Parse (GameObject.Find ("k4").GetComponent<Text> ().text) * 10).ToString ();
				Rigidbody a = GameObject.Find ("4").GetComponent<Rigidbody> ();
				a.velocity = Vector3.zero;
				a.angularVelocity = Vector3.zero;
			}
			flag = true;
			timeCount = 20;
			if (PhotonNetwork.player.ID == 1) {
				ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable (){ { "state","start" } };
				PhotonNetwork.player.SetCustomProperties (hash);
			}
			//라운드종료시점수통합
			Text k1, k2, k3, k4, sum1, sum2, sum3, sum4;
			k1 = GameObject.Find ("k1").GetComponent<Text> ();
			k2 = GameObject.Find ("k2").GetComponent<Text> ();
			k3 = GameObject.Find ("k3").GetComponent<Text> ();
			k4 = GameObject.Find ("k4").GetComponent<Text> ();

			sum1 = GameObject.Find ("sum1").GetComponent<Text> ();
			sum2 = GameObject.Find ("sum2").GetComponent<Text> ();
			sum3 = GameObject.Find ("sum3").GetComponent<Text> ();
			sum4 = GameObject.Find ("sum4").GetComponent<Text> ();
			int hap1, hap2, hap3, hap4;
			hap1 = int.Parse (sum1.text) + int.Parse (k1.text);
			hap2 = int.Parse (sum2.text) + int.Parse (k2.text);
			hap3 = int.Parse (sum3.text) + int.Parse (k3.text);
			hap4 = int.Parse (sum4.text) + int.Parse (k4.text);

			sum1.text = hap1.ToString ();
			sum2.text = hap2.ToString ();
			sum3.text = hap3.ToString ();
			sum4.text = hap4.ToString ();

			//
			gameTimeText.text = msg.ToString ();

			pmoney1.text = (int.Parse(GameObject.Find ("money1p").GetComponent<Text> ().text) +10 + int.Parse (GameObject.Find ("k1").GetComponent<Text> ().text) * 10).ToString () ;
			if(PhotonNetwork.playerList.Length>1)
				pmoney2.text = (int.Parse(GameObject.Find ("money2p").GetComponent<Text> ().text) +10 + int.Parse (GameObject.Find ("k2").GetComponent<Text> ().text) * 10).ToString () ;
			if(PhotonNetwork.playerList.Length>2)
				pmoney3.text = (int.Parse(GameObject.Find ("money3p").GetComponent<Text> ().text) +10 + int.Parse (GameObject.Find ("k3").GetComponent<Text> ().text) * 10).ToString () ;
			if(PhotonNetwork.playerList.Length>3)
				pmoney4.text = (int.Parse(GameObject.Find ("money4p").GetComponent<Text> ().text) +10 + int.Parse (GameObject.Find ("k4").GetComponent<Text> ().text) * 10).ToString () ;
			k1.text = "0";
			k2.text = "0";
			k3.text = "0";
			k4.text = "0";
			gameStateTimer = "a";
		} else {
			//game end
			Text k1, k2, k3, k4, sum1, sum2, sum3, sum4;
			k1 = GameObject.Find ("k1").GetComponent<Text> ();
			k2 = GameObject.Find ("k2").GetComponent<Text> ();
			k3 = GameObject.Find ("k3").GetComponent<Text> ();
			k4 = GameObject.Find ("k4").GetComponent<Text> ();

			sum1 = GameObject.Find ("sum1").GetComponent<Text> ();
			sum2 = GameObject.Find ("sum2").GetComponent<Text> ();
			sum3 = GameObject.Find ("sum3").GetComponent<Text> ();
			sum4 = GameObject.Find ("sum4").GetComponent<Text> ();
			int hap1, hap2, hap3, hap4;
			hap1 = int.Parse (sum1.text) + int.Parse (k1.text);
			hap2 = int.Parse (sum2.text) + int.Parse (k2.text);
			hap3 = int.Parse (sum3.text) + int.Parse (k3.text);
			hap4 = int.Parse (sum4.text) + int.Parse (k4.text);

			sum1.text = hap1.ToString ();
			sum2.text = hap2.ToString ();
			sum3.text = hap3.ToString ();
			sum4.text = hap4.ToString ();
			GameObject mainCam = GameObject.Find("Main Camera");
			mainCam.GetComponent<Camera> ().enabled = false;
			mainCam = GameObject.Find ("EndCamera");
			mainCam.GetComponent<Camera> ().enabled = true;
			AuctionInfoItemText.enabled = false;
			AuctionItemImage.SetActive (false);
			propelTime = 1;
			PlayTime.enabled = false;
			AuctionCanvas.enabled = false;
			Text kill1, kill2, kill3, kill4;
			Text survive1, survive2, survive3, survive4;
			Text score1, score2, score3, score4;
			Text Rank1, Rank2, Rank3, Rank4;
			kill1 = GameObject.Find ("killResult1").GetComponent<Text> ();
			kill2 = GameObject.Find ("killResult2").GetComponent<Text> ();
			kill3 = GameObject.Find ("killResult3").GetComponent<Text> ();
			kill4 = GameObject.Find ("killResult4").GetComponent<Text> ();
			kill1.text = GameObject.Find ("sum1").GetComponent<Text> ().text;
			kill2.text = GameObject.Find ("sum2").GetComponent<Text> ().text;
			kill3.text = GameObject.Find ("sum3").GetComponent<Text> ().text;
			kill4.text = GameObject.Find ("sum4").GetComponent<Text> ().text;

			survive1 = GameObject.Find ("surviveResult1").GetComponent<Text> ();
			survive2 = GameObject.Find ("surviveResult2").GetComponent<Text> ();
			survive3 = GameObject.Find ("surviveResult3").GetComponent<Text> ();
			survive4 = GameObject.Find ("surviveResult4").GetComponent<Text> ();
			survive1.text = GameObject.Find ("save1").GetComponent<Text> ().text;
			survive2.text = GameObject.Find ("save2").GetComponent<Text> ().text;
			survive3.text = GameObject.Find ("save3").GetComponent<Text> ().text;
			survive4.text = GameObject.Find ("save4").GetComponent<Text> ().text;

			score1 = GameObject.Find ("scoreResult1").GetComponent<Text> ();
			score2 = GameObject.Find ("scoreResult2").GetComponent<Text> ();
			score3 = GameObject.Find ("scoreResult3").GetComponent<Text> ();
			score4 = GameObject.Find ("scoreResult4").GetComponent<Text> ();
			score1.text = (int.Parse (kill1.text) * 100 + int.Parse (survive1.text) * 150).ToString ();
			score2.text = (int.Parse (kill2.text) * 100 + int.Parse (survive2.text) * 150).ToString ();
			score3.text = (int.Parse (kill3.text) * 100 + int.Parse (survive3.text) * 150).ToString ();
			score4.text = (int.Parse (kill4.text) * 100 + int.Parse (survive4.text) * 150).ToString ();

			int p1, p2, p3, p4;
			p1 = int.Parse (score1.text);
			p2 = int.Parse (score2.text);
			p3 = int.Parse (score3.text);
			p4 = int.Parse (score4.text);
			int[] score = { p1, p2, p3, p4 };
			int[] rank = new int[4];
			int saveRank = 0;
			for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
				saveRank = 0;
				for (int j = 0; j < PhotonNetwork.playerList.Length; j++) {
					if (score [i] < score [j])
						saveRank++;
				}
				rank [i] = saveRank + 1;
			}
			Debug.Log(PhotonNetwork.playerList.Length.ToString ());
			Rank1 = GameObject.Find ("rankResult1").GetComponent<Text> ();
			Rank2 = GameObject.Find ("rankResult2").GetComponent<Text> ();
			Rank3 = GameObject.Find ("rankResult3").GetComponent<Text> ();
			Rank4 = GameObject.Find ("rankResult4").GetComponent<Text> ();
			Rank1.text = rank [0].ToString () + " 등";
			if (PhotonNetwork.playerList.Length >= 2)
				Rank2.text = rank [1].ToString () + " 등";
			else
				Rank2.text = "0";

			if (PhotonNetwork.playerList.Length >= 3)
				Rank3.text = rank [2].ToString () + " 등";
			else
				Rank3.text = "0";

			if (PhotonNetwork.playerList.Length >= 4)
				Rank4.text = rank [3].ToString () + " 등";
			else
				Rank4.text = "0";
		}
	}

	//auction timer
	[PunRPC]
	public void sendTime(int msg,int ran,string state, PhotonMessageInfo info){
		changeTime (msg,state);
		RandomAuction(ran); 
	}
	public void printTime(int ta,int ran,string state){
		Send (PhotonTargets.All, ta,ran,state);
	}
	void Send(PhotonTargets target, int msg,int ran,string state){
		pv.RPC ("sendTime", target, msg,ran,state);
	}
	public void changeTime(int msg,string state){

		TimeText.text = msg.ToString ();
		game_start = true;
		start = true;

		GameObject[] sto = GameObject.FindGameObjectsWithTag ("Stone");
		for (int i = 0; i < sto.Length; i++) {
			if (sto [i].GetComponent<PhotonView> ().owner.ID == 1) {
				Text p1 = GameObject.Find ("p1").GetComponent<Text> ();
				p1.text = sto [i].GetComponent<PhotonView> ().owner.NickName;
			}else if (sto [i].GetComponent<PhotonView> ().owner.ID == 2) {
				Text p1 = GameObject.Find ("p2").GetComponent<Text> ();
				p1.text = sto [i].GetComponent<PhotonView> ().owner.NickName;
			}else if (sto [i].GetComponent<PhotonView> ().owner.ID == 3) {
				Text p1 = GameObject.Find ("p3").GetComponent<Text> ();
				p1.text = sto [i].GetComponent<PhotonView> ().owner.NickName;
			}else if (sto [i].GetComponent<PhotonView> ().owner.ID == 4) {
				Text p1 = GameObject.Find ("p4").GetComponent<Text> ();
				p1.text = sto [i].GetComponent<PhotonView> ().owner.NickName;
			}
		}

	}

	public void RandomAuction(int ran)
	{

		if(flag == true)
		{ 
			gameState = "Auction";
			rand = ran;
			switch (rand)
			{
			case 1:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/default") as Sprite;
				break;
			case 2:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/blue") as Sprite;
				break;

			case 3:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/chocolate") as Sprite;
				break;

			case 4:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/coffe") as Sprite;
				break;

			case 5:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/green") as Sprite;
				break;
			case 6:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/marron") as Sprite;
				break;
			case 7:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/rio") as Sprite;
				break;
			case 8:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/white") as Sprite;
				break;
			case 9:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/floortile") as Sprite;
				break;
			case 10:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/glass") as Sprite;
				break;
			case 11:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/grass") as Sprite;
				break;
			case 12:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/mudrocky") as Sprite;
				break;
			case 13:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/pavement_1") as Sprite;
				break;
			case 14:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/pavement_2") as Sprite;
				break;
			case 15:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/splash_1") as Sprite;
				break;
			case 16:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/splash_2") as Sprite;
				break;
			case 17:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/DarkBlueOpacityMaterial") as Sprite;
				break;
			case 18:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/DarkPurpleOpacityMaterial") as Sprite;
				break;
			case 19:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/DarkRedOpacityMaterial") as Sprite;
				break;
			case 20:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/Flare50mm") as Sprite;
				break;
			case 21:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/LightGreenOpacityMaterial") as Sprite;
				break;	
			case 22:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/LightGrayOpacityMaterial") as Sprite;
				break;
			case 23:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/Orange") as Sprite;
				break;
			case 24:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/SkyCarLightGlows") as Sprite;
				break;
			case 25:
				AuctionItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("StoneImage/YellowOpacityMaterial") as Sprite;
				break;
			}
			flag = false;

		}

	}
	//경매아이템 클릭시 돌의 정보 출력 on/off
	public void AuctionItemInfo(int a){
		if (game_start == true) {

			if (AuctionInfoItemText.enabled == false) {
				AuctionInfoItemText.enabled = true;
				AuctionItemImage.SetActive (false);
				string info = "이름 : " + stoneinfo[rand-1].StoneName + "\n공격력 : " + stoneinfo [rand - 1].mass + "\n체력 : " + stoneinfo [rand - 1].Hp + "\n크기 : " + stoneinfo [rand - 1].scale;
				AuctionInfoItemText.text = info;
			} else {
				AuctionInfoItemText.enabled = false;
				AuctionItemImage.SetActive (true);
			}
		}
	}
}
