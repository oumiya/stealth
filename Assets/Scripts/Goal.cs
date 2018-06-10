using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Player.Scene == Player.Scenes.Active)
        {
            // Playerとぶつかったらゲームクリア
            if (other.transform.tag == "Player")
            {
                Player.Scene = Player.Scenes.GameClear;
            }
        }
    }
}
