using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.Scene == Player.Scenes.FadeOut)
        {
            GetComponent<Text>().enabled = true;
        }
        if (Player.Scene == Player.Scenes.FadeIn)
        {
            GetComponent<Text>().enabled = false;
        }
    }
}
