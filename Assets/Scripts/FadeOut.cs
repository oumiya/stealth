﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour {

    public float speed = 0.01f;
    float alpha;
    float red, green, blue;

    private AudioSource[] audios;

    float clearStartTime;

	// Use this for initialization
	void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        audios = GetComponents<AudioSource>();

        audios[2].Play();
    }
	
	// Update is called once per frame
	void Update () {
		if (Player.Scene == Player.Scenes.FadeOut)
        {
            if (!audios[0].isPlaying)
            {
                audios[0].Play();
            }

            GetComponent<Image>().color = new Color(red, green, blue, alpha);
            alpha += speed;
            if (alpha >= 1.0f)
            {
                Player.Scene = Player.Scenes.FadeIn;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Player>().Restart();
            }
        }

        if (Player.Scene == Player.Scenes.FadeIn)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alpha);
            alpha -= speed;
            if (alpha <= 0f)
            {
                if (audios[0].isPlaying)
                {
                    audios[0].Stop();
                }
                Player.Scene = Player.Scenes.Active;
            }
        }

        if (Player.Scene == Player.Scenes.GameClear)
        {
            if (!audios[1].isPlaying)
            {
                audios[2].Stop();
                audios[1].Play();
                clearStartTime = Time.time;
            }

            GetComponent<Image>().color = new Color(red, green, blue, 0.7f);

            if (Time.time - clearStartTime >= 4.675f)
            {
                Player.Scene = Player.Scenes.Active;
                SceneManager.LoadScene("TitleScene");

            }
        }
	}
}
