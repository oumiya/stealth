using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public float speed = 0.01f;
    float alpha;
    float red, green, blue;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Player.Scene == Player.Scenes.FadeOut)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
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
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                Player.Scene = Player.Scenes.Active;
            }
        }
	}
}
