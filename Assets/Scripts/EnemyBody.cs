using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵本体のルーチン。
/// 移動ルーチンは適当に進んで行って壁や敵にぶつかったらランダムに方向転換する
/// </summary>
public class EnemyBody : MonoBehaviour {

    enum Direction { Up = 0, Right = 1, Down = 2, Left = 3};

    float speed = 3.0f;

    Vector3 initialPosition;
    Vector3 initialForward;

	// Use this for initialization
	void Start () {
        // 初期に向いている角度を決定
        Direction d = (Direction)Random.Range(0, 4);

        switch (d)
        {
            case Direction.Up:
                break;
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

        // 初期配置の場所を覚えておく
        initialPosition = transform.position;
        initialForward = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.Scene == Player.Scenes.Active)
        {
            // 壁にぶつかったら右か左にランダムで方向転換する
            transform.position += transform.forward * speed * Time.deltaTime;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Player.Scene == Player.Scenes.Active)
        {
            // 壁や敵とぶつかったら方向転換
            if (other.transform.tag == "Wall" || other.transform.tag == "Enemy")
            {
                // 後退して壁から離れる
                transform.position -= transform.forward * speed * 2 * Time.deltaTime;

                Direction d = (Direction)Random.Range(1, 4);

                switch (d)
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

    public void Restart()
    {
        transform.position = initialPosition;
        transform.forward = initialForward;
    }
}
