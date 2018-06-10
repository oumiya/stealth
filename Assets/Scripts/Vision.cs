using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.Scene == Player.Scenes.Active)
        {
            // 親オブジェクトからEnemyBodyを見つける
            GameObject enemyBody = transform.parent.Find("EnemyBody").gameObject;
            transform.position = enemyBody.transform.position;
            transform.forward = enemyBody.transform.forward;
            transform.position += transform.forward * 250f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 主人公とぶつかったらゲームオーバー
        if (other.tag == "Player")
        {
            // フェードアウト処理をする
            Player.Scene = Player.Scenes.FadeOut;
        }
    }
}
