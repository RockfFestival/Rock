using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelStone : MonoBehaviour
{
    [SerializeField]
    public Rigidbody propel;

    float speed = 10000.0f;
    public float addSpeed = 30000.0f;
    public float stoneTorgue = 3000.0f;
    public float angularVelocity = 200000.0f;
    bool isPropeled = false;

    int propelCnt = 0;
    // Use this for initialization

	void Awake()
    {

        propel = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AuctionTime.propelTime <= 0 && isPropeled == false)
        {
            StartCoroutine("WaitAuction");
            isPropeled = true;
        }

        if (GrondSpeedUp.OnGroundFlag == 1)
        {
            //여기다 속도업 한번만
            switch (OnAuctionEventMrg.playerID)
            {
                case 1:
                    if (propelCnt == 0)
                    {
                        propel.AddForce(Vector3.forward * propel.mass * addSpeed);
                        propel.maxAngularVelocity = angularVelocity;
                        //왼손 힘의 법칙에 의거
                        propel.AddTorque(Vector3.right * stoneTorgue);
                        propelCnt = 1;
                    }
                    break;
                case 2:
                    if (propelCnt == 0)
                    {
                        propel.AddForce(Vector3.back * propel.mass * addSpeed);
                        propel.maxAngularVelocity = angularVelocity;
                        //왼손 힘의 법칙에 의거
                        propel.AddRelativeTorque(Vector3.left * stoneTorgue);
                        propelCnt = 1;
                    }
                    break;
                case 3:
                    if (propelCnt == 0)
                    {
                        propel.AddForce(Vector3.right * propel.mass * addSpeed);
                        propel.maxAngularVelocity = angularVelocity;
                        //왼손 힘의 법칙에 의거
                        propel.AddRelativeTorque(Vector3.back * stoneTorgue);
                        propelCnt = 1;
                    }
                    break;
                case 4:
                    if (propelCnt == 0)
                    {
                        propel.AddForce(Vector3.left * propel.mass * addSpeed);
                        propel.maxAngularVelocity = angularVelocity;
                        //왼손 힘의 법칙에 의거
                        propel.AddRelativeTorque(Vector3.forward * stoneTorgue);
                        propelCnt = 1;
                    }
                    break;

            }


            GrondSpeedUp.OnGroundFlag = 0;
        }
 
    }

    

    IEnumerator WaitAuction()
    {
            StartCoroutine(MoveStone());
            yield return new WaitForSeconds(10.0f);
    }

    IEnumerator MoveStone()
    {
            propel.AddRelativeForce(Vector3.forward * propel.mass * speed);
            yield return new WaitForSeconds(0.1f);
    }


        


}