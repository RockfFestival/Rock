using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Cancle : MonoBehaviour {


    public Text Gold;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    public void OnClick_Cancle()
    {
        Gold.GetComponent<Text>().text = (0).ToString();

    }
}
