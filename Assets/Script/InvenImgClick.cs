using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InvenImgClick : Photon.MonoBehaviour {
	private PhotonView pv;
	public Canvas ItemInfoCanvas;
	public Text Info;
	public Text fStoneButton;

	public static int Hp;
	public static int mass;
	public static int scale;
	public static int invenNumber=0;
	public static string stoneT;
	public static bool fStone;
	public static bool fir;
	public static string StoneName;
	public Image item_i1;
	public Image item_i2;
	public Image item_i3;
	public Image item_i4;
	public Image item_i5;

	// Use this for initialization
	void Awake () {
		ItemInfoCanvas.enabled = false;
		Hp = 0;
		mass = 0;
		scale = 0;
		fStone = false;
		stoneT = "";
		StoneName = "";
		pv = GetComponent<PhotonView> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ImgOneClick()
    {
			if (fStone == false) {
			if (AuctionTime.have_stone >= 1) {
				ItemInfoCanvas.enabled = true;
				Hp = AuctionTime.playerStone [0].Hp;
				mass = AuctionTime.playerStone [0].mass;
				scale = AuctionTime.playerStone [0].scale;
				stoneT = AuctionTime.playerStone [0].stoneTexture;
				fir = AuctionTime.playerStone [0].firstStone;
				StoneName = AuctionTime.playerStone [0].StoneName;
				Info.text = "이름 : " + StoneName + "\n체력 : " + Hp.ToString () + "\n공격력 : " + mass.ToString () + "\n크기 : " + scale.ToString ();
				invenNumber = 1;
			}
			} else {
				if (invenNumber != 1) {

					AuctionTime.playerStone [invenNumber - 1].check = false;
					AuctionTime.playerStone [0].check = false;
					invenSort ();
					Item_print_inven ();
					fStone = false;
					fStoneButton.text = "합성";
					ItemInfoCanvas.enabled = false;
				} else {
					Debug.Log ("already selected");
				}
			}
    }
    public void ImgTwoClick()
    {
		if (fStone == false) {
			
			if (AuctionTime.have_stone >= 2) {
			
				ItemInfoCanvas.enabled = true;
				Hp = AuctionTime.playerStone [1].Hp;
				mass = AuctionTime.playerStone [1].mass;
				scale = AuctionTime.playerStone [1].scale;
				stoneT = AuctionTime.playerStone [1].stoneTexture;
				fir = AuctionTime.playerStone [1].firstStone;
				StoneName = AuctionTime.playerStone [1].StoneName;
				Info.text = "이름 : " + StoneName + "\n체력 : " + Hp.ToString () + "\n공격력 : " + mass.ToString () + "\n크기 : " + scale.ToString ();
				invenNumber = 2;
			}
		}
		else {
			if (invenNumber != 2) {
				AuctionTime.playerStone [invenNumber - 1].check = false;
				AuctionTime.playerStone [1].check = false;
				invenSort ();
				Item_print_inven();
				fStone = false;
				fStoneButton.text = "합성";
				ItemInfoCanvas.enabled = false;

			}
			else {
				Debug.Log ("already selected");
			}
		}
    }
    public void ImgThreeClick()
    {
		if (fStone == false) {
			
			if (AuctionTime.have_stone >= 3) {
			
				ItemInfoCanvas.enabled = true;
				Hp = AuctionTime.playerStone [2].Hp;
				mass = AuctionTime.playerStone [2].mass;
				scale = AuctionTime.playerStone [2].scale;
				stoneT = AuctionTime.playerStone [2].stoneTexture;
				fir = AuctionTime.playerStone [2].firstStone;
				StoneName = AuctionTime.playerStone [2].StoneName;
				Info.text = "이름 : " + StoneName + "\n체력 : " + Hp.ToString () + "\n공격력 : " + mass.ToString () + "\n크기 : " + scale.ToString ();
				invenNumber = 3;
			}
		}
		else {
			if (invenNumber != 3) {
				AuctionTime.playerStone [invenNumber - 1].check = false;
				AuctionTime.playerStone [2].check = false;
				invenSort ();
				Item_print_inven();
				fStone = false;
				fStoneButton.text = "합성";
				ItemInfoCanvas.enabled = false;

			}
			else {
				Debug.Log ("already selected");
			}
		}
    }
    public void ImgFourClick()
    {
		if (fStone == false) {
			
			if (AuctionTime.have_stone >= 4) {

				ItemInfoCanvas.enabled = true;
				Hp = AuctionTime.playerStone [3].Hp;
				mass = AuctionTime.playerStone [3].mass;
				scale = AuctionTime.playerStone [3].scale;
				stoneT = AuctionTime.playerStone [3].stoneTexture;
				fir = AuctionTime.playerStone [3].firstStone;
				StoneName = AuctionTime.playerStone [3].StoneName;
				Info.text = "이름 : " + StoneName + "\n체력 : " + Hp.ToString () + "\n공격력 : " + mass.ToString () + "\n크기 : " + scale.ToString ();
				invenNumber = 4;
			}
		}
		else {
			if (invenNumber != 4) {
				AuctionTime.playerStone [invenNumber - 1].check = false;
				AuctionTime.playerStone [3].check = false;
				invenSort ();
				Item_print_inven();
				fStone = false;
				fStoneButton.text = "합성";
				ItemInfoCanvas.enabled = false;

			}
			else {
				Debug.Log ("already selected");
			}
		}
    }
    public void ImgFiveClick()
    {
		if (fStone == false) {
			
			if (AuctionTime.have_stone >= 5) {

				ItemInfoCanvas.enabled = true;
				Hp = AuctionTime.playerStone [4].Hp;
				mass = AuctionTime.playerStone [4].mass;
				scale = AuctionTime.playerStone [4].scale;
				stoneT = AuctionTime.playerStone [4].stoneTexture;
				fir = AuctionTime.playerStone [4].firstStone;
				StoneName = AuctionTime.playerStone [4].StoneName;
				Info.text = "이름 : " + StoneName + "\n체력 : " + Hp.ToString () + "\n공격력 : " + mass.ToString () + "\n크기 : " + scale.ToString ();
				invenNumber = 5;
			}
		}
		else {
			if (invenNumber !=5) {
				AuctionTime.playerStone [invenNumber - 1].check = false;
				AuctionTime.playerStone [4].check = false;
				invenSort ();
				Item_print_inven();
				fStone = false;
				fStoneButton.text = "합성";
				ItemInfoCanvas.enabled = false;

			}
			else {
				Debug.Log ("already selected");
			}
		}
    }
	public void Hideinfo(){


		ItemInfoCanvas.enabled = false;
	}
	public void use(){
		if (AuctionTime.gameState == "Auction") {
			changescale (PhotonNetwork.player.ID, InvenImgClick.Hp, InvenImgClick.mass, InvenImgClick.scale, InvenImgClick.stoneT);
			if (fir == false) {
				invenUseSort ();
				Item_print_inven();
			}
		}
	}

	public void changescale(int id, int hp, int mass, int scale,string stoneTexture){
		change (PhotonTargets.All,id, hp, mass, scale,stoneTexture);

	}
	void change(PhotonTargets target, int id,int hp, int mass, int scale,string stoneTexture){
		pv.RPC ("check", target, id,hp, mass, scale,stoneTexture);
	}
	[PunRPC]
	public void check(int id,int hp, int mass, int scale,string stoneTexture){
		ChangeStone (id,hp, mass, scale,stoneTexture);
	}
	public void ChangeStone(int id,int Hp, int ma, int sc,string stoneTexture){
		GameObject[] ga = GameObject.FindGameObjectsWithTag ("Stone");
		for (int i = 0; i < ga.Length; i++) {
			if (id == ga [i].GetComponent<PhotonView> ().ownerId) {
				ga [i].transform.localScale = new Vector3 (sc, sc, sc);
				ga [i].GetComponent<Rigidbody> ().mass = ma;
				ga [i].GetComponent<FracturedObject> ().EventDetachMinMass = Hp;
				Renderer[] child = ga [i].gameObject.GetComponentsInChildren<Renderer> ();
				Material[] mat = new Material[2];
				mat [0] = Resources.Load (stoneTexture) as Material;
				mat [1] = Resources.Load (stoneTexture) as Material;
				for(int l=0;l<child.Length;l++){
					child [l].GetComponent<MeshRenderer> ().materials = mat;
				}
			}
		}
	}

	public void fusion(){
		if (AuctionTime.gameState == "Auction") {
			if (fStone == false) {
				fStoneButton.text = "취소";
				fStone = true;
			} else {
				fStoneButton.text = "합성";
				fStone = false;
				for(int i=0;i<AuctionTime.have_stone;i++)
				{
					AuctionTime.playerStone [i].check = true;
				}
			}
		}
	}
	public void invenUseSort(){
		AuctionTime.have_stone--;
		if (invenNumber == 1) {
			for (int i = 0; i < 4; i++) {
				AuctionTime.playerStone [i] = AuctionTime.playerStone [i + 1];
			}

		} else if (invenNumber == 2) {
			for (int i = 1; i < 4; i++) {
				AuctionTime.playerStone [i] = AuctionTime.playerStone [i + 1];
			}
		}else if (invenNumber == 3) {
			for (int i = 2; i < 4; i++) {
				AuctionTime.playerStone [i] = AuctionTime.playerStone [i + 1];
			}
		}else if (invenNumber == 4) {
			for (int i = 3; i < 4; i++) {
				AuctionTime.playerStone [i] = AuctionTime.playerStone [i + 1];
			}
		}
		ItemInfoCanvas.enabled = false;
	}
	public void invenSort(){
		int[] true_check = new int[5];
		int save = 0;
		for (int i = 0; i < AuctionTime.have_stone; i++) {
			if (AuctionTime.playerStone [i].check == true) {
				true_check [save] = i;
				save++;
			}
		}

		for (int i = 0; i < save; i++) {
			AuctionTime.playerStone [i] = AuctionTime.playerStone [true_check[i]];
		}
		AuctionTime.have_stone = AuctionTime.have_stone - 1;
		if(AuctionTime.roundCount==1)
			AuctionTime.playerStone [AuctionTime.have_stone - 1] = AuctionTime.stoneinfo [UnityEngine.Random.Range (0, 5)];
		else if(AuctionTime.roundCount==2)
			AuctionTime.playerStone [AuctionTime.have_stone - 1] = AuctionTime.stoneinfo [UnityEngine.Random.Range (5, 10)];
		else if(AuctionTime.roundCount==3)
			AuctionTime.playerStone [AuctionTime.have_stone - 1] = AuctionTime.stoneinfo [UnityEngine.Random.Range (10, 15)];
		else if(AuctionTime.roundCount==4)
			AuctionTime.playerStone [AuctionTime.have_stone - 1] = AuctionTime.stoneinfo [UnityEngine.Random.Range (15, 20)];
		else if(AuctionTime.roundCount==5)
			AuctionTime.playerStone [AuctionTime.have_stone - 1] = AuctionTime.stoneinfo [UnityEngine.Random.Range (20, 25)];
		
	}
	public void Item_print_inven(){
		item_i1.sprite = Resources.Load<Sprite>("StoneImage/invenDefault") as Sprite;
		item_i2.sprite = Resources.Load<Sprite>("StoneImage/invenDefault") as Sprite;
		item_i3.sprite =Resources.Load<Sprite>("StoneImage/invenDefault") as Sprite;
		item_i4.sprite = Resources.Load<Sprite>("StoneImage/invenDefault") as Sprite;
		item_i5.sprite = Resources.Load<Sprite>("StoneImage/invenDefault") as Sprite;
		for (int i = 0; i < AuctionTime.have_stone; i++) {
			switch (i) {
			case 0:
				item_i1.sprite = Resources.Load<Sprite>(AuctionTime.playerStone[0].imageString) as Sprite;
				break;
			case 1:
				item_i2.sprite = Resources.Load<Sprite>(AuctionTime.playerStone[1].imageString) as Sprite;
				break;
			case 2:
				item_i3.sprite = Resources.Load<Sprite>(AuctionTime.playerStone[2].imageString) as Sprite;
				break;
			case 3:
				item_i4.sprite = Resources.Load<Sprite>(AuctionTime.playerStone[3].imageString) as Sprite;
				break;
			case 4:
				item_i5.sprite = Resources.Load<Sprite>(AuctionTime.playerStone[4].imageString) as Sprite;
				break;
			}
		}
	}
}
