﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button10 : MonoBehaviour {

    public Text Gold;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    public void OnClick_10()
    {
        int i;
        i = int.Parse(Gold.GetComponent<Text>().text);
        Gold.GetComponent<Text>().text = (i + 10).ToString();

    }
}
