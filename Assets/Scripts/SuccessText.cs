﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.Scene == Player.Scenes.GameClear)
        {
            GetComponent<Text>().enabled = true;
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
