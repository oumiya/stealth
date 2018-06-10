using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 5.0f;
    float gravity = 9.81f;

    Vector3 moveDirection = Vector3.zero;

    CharacterController characterController;

    Vector3 initialPosition;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        // 初期配置を記憶
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
	}

    public void Restart()
    {
        // 主人公と敵を全て初期位置に戻す
        transform.position = initialPosition;

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemys)
        {
            enemy.GetComponent<EnemyBody>().Restart();
        }
    }
}
