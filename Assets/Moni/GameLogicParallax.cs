using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicParallax : MonoBehaviour
{

    public Camera cam;
    //PlayerParallax player;
    //public AudioClip otherClip;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindObjectsOfType<PlayerParallax>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.Translate(0.1f, 0, 0);
/* 
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Jump");
            player.jump();
        }

        if (!cam.GetComponent<AudioSource>().isPlaying)
        {
            cam.GetComponent<AudioSource>().clip = otherClip;
            cam.GetComponent<AudioSource>().loop = true;
            cam.GetComponent<AudioSource>().Play();
        }*/
    }
}
