using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    public Transform tr;
    public Transform playerName;
    public GameObject player;
    private Transform mainCam;

    public float camPositionY = 48.0f;
    public float camPositionZorX = 80.0f;
    public Transform[] nameCard = new Transform[4];

    // Use this for initialization
    void Awake()
    {
        tr = GetComponent<Transform>();

        mainCam = Camera.main.transform;
        Camera.main.farClipPlane = 5000.0f;
        nameCard[0] = GameObject.Find("1Name").GetComponent<Transform>();
        nameCard[1] = GameObject.Find("2Name").GetComponent<Transform>();
        nameCard[2] = GameObject.Find("3Name").GetComponent<Transform>();
        nameCard[3] = GameObject.Find("4Name").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnAuctionEventMrg.isStart == true)
        {
            GameObject[] st = GameObject.FindGameObjectsWithTag("Stone");

            for (int i = 0; i < st.Length; i++)
            {
                if (st[i].GetComponent<PhotonView>().owner.ID == 1) // 1번 플레이어
                {
                    player = st[i];
                    playerName = nameCard[0];
                    //플레이어 이름 위치
                    playerName.position = new Vector3(player.transform.position.x, player.transform.position.y + 30.0f, player.transform.position.z - 33.0f);

                    //카메라 위치
                    if (PhotonNetwork.player.ID == 1)
                    {
                        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + camPositionY, player.transform.position.z - camPositionZorX);
                        transform.LookAt(playerName);
                    }

                }
                else if (st[i].GetComponent<PhotonView>().owner.ID == 2)
                {
                    player = st[i];
                    Vector3 dir = new Vector3(0, 180, 0);
                    playerName = nameCard[1];
                    playerName.position = new Vector3(player.transform.position.x, player.transform.position.y + 30.0f, player.transform.position.z + 33.0f);
                    playerName.eulerAngles = dir;

                    if (PhotonNetwork.player.ID == 2)
                    {
                        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + camPositionY, player.transform.position.z + camPositionZorX);
                        transform.LookAt(playerName);
                    }
                }
                else if (st[i].GetComponent<PhotonView>().owner.ID == 3)
                {
                    player = st[i];
                    Vector3 dir = new Vector3(0, 90, 0);
                    playerName = nameCard[2];
                    playerName.position = new Vector3(player.transform.position.x - 30.0f, player.transform.position.y + 30.0f, player.transform.position.z);
                    playerName.eulerAngles = dir;

                    if (PhotonNetwork.player.ID == 3)
                    {
                        transform.position = new Vector3(player.transform.position.x - camPositionZorX, player.transform.position.y + camPositionY, player.transform.position.z);
                        transform.LookAt(playerName);
                    }

                }
                else if (st[i].GetComponent<PhotonView>().owner.ID == 4)
                {
                    player = st[i];
                    Vector3 dir = new Vector3(0, 270, 0);
                    playerName = nameCard[3];
                    playerName.position = new Vector3(player.transform.position.x + 30.0f, player.transform.position.y + 23.0f, player.transform.position.z);
                    playerName.eulerAngles = dir;

                    if (PhotonNetwork.player.ID == 4)
                    {
                        transform.position = new Vector3(player.transform.position.x + camPositionZorX, player.transform.position.y + camPositionY, player.transform.position.z);
                        transform.LookAt(playerName);
                    }
                }
            }
        }

    }


}
