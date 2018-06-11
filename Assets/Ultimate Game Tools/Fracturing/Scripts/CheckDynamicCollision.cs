using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/// <summary>
/// This component will enable fracturable objects with dynamic properties
/// </summary>
public class CheckDynamicCollision : Photon.MonoBehaviour
{
	public PhotonView pv;
	public GameObject juk;
	Text k1,k2,k3,k4;
	bool mujuk;
	void Awake()
    {
        // Enable fracturable object collider
		mujuk=false;
        FracturedObject fracturedObject = GetComponent<FracturedObject>();
		pv = fracturedObject.GetComponent<PhotonView> ();
        // Disable chunk colliders
		k1= GameObject.Find ("k1").GetComponent<Text>();
		k2 = GameObject.Find ("k2").GetComponent<Text>();
		k3 = GameObject.Find ("k3").GetComponent<Text>();
		k4 = GameObject.Find ("k4").GetComponent<Text>();
        if(fracturedObject != null)
        {
            if(fracturedObject.GetComponent<Collider>() != null)
            {
                fracturedObject.GetComponent<Collider>().enabled = true;
            }
            else
            {
                Debug.LogWarning("Fracturable Object " + gameObject.name + " has a dynamic rigidbody but no collider. Object will not be able to collide.");
            }

            for(int i = 0; i < fracturedObject.ListFracturedChunks.Count; i++)
            {
                EnableObjectColliders(fracturedObject.ListFracturedChunks[i].gameObject, false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Stone") {
			if(mujuk==false){
				mujuk = true;
			if (collision.contacts == null) {
				return;
			}

			if (collision.contacts.Length == 0) {
				return;
			}

			// Was it a big enough hit?

			FracturedObject fracturedObject = gameObject.GetComponent<FracturedObject> ();

				if (fracturedObject != null) {
					float fMass = collision.rigidbody != null ? collision.rigidbody.mass : Mathf.Infinity;
					if (collision.relativeVelocity.magnitude > fracturedObject.EventDetachMinVelocity && fMass > fracturedObject.EventDetachMinVelocity) {
						// Disable fracturable object collider
						if (collision.rigidbody != null) {
							fracturedObject.EventDetachMinMass -= collision.rigidbody.mass;
						}
						if (fracturedObject.EventDetachMinMass < 0) {
							//Debug.Log (collision.gameObject.GetComponent<PhotonView> ().ownerId.ToString ());
							//부순사람 카운트 업
							if(collision.gameObject.GetComponent<PhotonView> ().owner.ID==1)
								SendKill (collision.gameObject.GetComponent<PhotonView> ().owner.ID,k1.text);
							if(collision.gameObject.GetComponent<PhotonView> ().owner.ID==2)
								SendKill (collision.gameObject.GetComponent<PhotonView> ().owner.ID,k2.text);
							if(collision.gameObject.GetComponent<PhotonView> ().owner.ID==3)
								SendKill (collision.gameObject.GetComponent<PhotonView> ().owner.ID,k3.text);
							if(collision.gameObject.GetComponent<PhotonView> ().owner.ID==4)
								SendKill (collision.gameObject.GetComponent<PhotonView> ().owner.ID,k4.text);
							//부셔진돌 캔버스 제거
							fracturedObject.GetComponent<Collider> ().enabled = false;

							Rigidbody fracturableRigidbody = fracturedObject.GetComponent<Rigidbody> ();

							if (fracturableRigidbody != null) {
								fracturableRigidbody.isKinematic = true;
							}
							for (int i = 0; i < fracturedObject.ListFracturedChunks.Count; i++) {
								EnableObjectColliders (fracturedObject.ListFracturedChunks [i].gameObject, true);
							}

							// Explode

							fracturedObject.Explode (collision.contacts [0].point, collision.relativeVelocity.magnitude);
							//죽은돌 삭제
							GameObject delStone = GameObject.Find (fracturedObject.name);
							Destroy (delStone);
						}
						// Enable chunk colliders

                
					}
				}
			}
			StartCoroutine ("divine");
		}

    }
	IEnumerator divine(){
		yield return new WaitForSeconds (1.0f);
		mujuk = false;
	}
    private void EnableObjectColliders(GameObject chunk, bool bEnable)
    {
        List<Collider> chunkColliders = new List<Collider>();

        SearchForAllComponentsInHierarchy<Collider>(chunk, ref chunkColliders);

        for(int i = 0; i < chunkColliders.Count; ++i)
        {
            chunkColliders[i].enabled = bEnable;

            if(bEnable)
            {
                chunkColliders[i].isTrigger = false;
            }
        }
    }

    private static void SearchForAllComponentsInHierarchy<T>(GameObject current, ref List<T> listOut) where T : Component
    {
      T myComponent = current.GetComponent<T>();

      if (myComponent != null)
      {
        listOut.Add(myComponent);
      }

      for (int i = 0; i < current.transform.childCount; ++i)
      {
        SearchForAllComponentsInHierarchy(current.transform.GetChild(i).gameObject, ref listOut);
      }
    }


	[PunRPC]
	public void SendKillRpc(int id,string kill, PhotonMessageInfo info){
		upKill (id,kill);
	}
	public void SendKill(int id,string kill){
		SendK (PhotonTargets.All, id,kill);
	}
	void SendK(PhotonTargets target, int id,string kill){
		pv.RPC ("SendKillRpc", target, id,kill);
	}
	public void upKill(int id,string kill){
		int save = 0;
		if (id == 1) {
			save = int.Parse (kill)+1;
			k1.text = save.ToString();
		}
		if (id == 2) {
			save = int.Parse (kill)+1;
			k2.text = save.ToString();
		}
		if (id == 3) {
			save = int.Parse (kill)+1;
			k3.text = save.ToString();
		}
		if (id == 4) {
			save = int.Parse (kill)+1;
			k4.text = save.ToString();
		}

	}

}
