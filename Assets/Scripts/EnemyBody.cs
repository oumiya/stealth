using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵本体のルーチン。
/// 移動ルーチンは適当に進んで行って壁にぶつかったらランダムに方向転換する
/// </summary>
public class EnemyBody : MonoBehaviour {

    enum Direction { Up = 0, Right = 1, Down = 2, Left = 3};

    float speed = 3.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // 壁にぶつかったら右か左にランダムで方向転換する
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        // 壁とぶつかったらしい
        if ( other.transform.tag == "Wall")
        {
            // 後退して壁から離れる
            transform.position -= transform.forward * speed * 2 * Time.deltaTime;

            Direction d = (Direction)Random.Range(1, 4);

            // 壁にぶつかったら方向転換する
            switch(d)
            {
                case Direction.Right:
                    transform.forward = transform.right;
                    break;
                case Direction.Down:
                    transform.forward = -transform.forward;
                    break;
                case Direction.Left:
                    transform.forward = -transform.right;
                    break;
            }
        }
    }
}
