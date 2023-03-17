using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public AudioClip audioClick;
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (audioSrc.GetComponent<AudioSource>().isPlaying) return;
            else audioSrc.GetComponent<AudioSource>().PlayOneShot(audioClick);
            //if (!audioSrc.isPlaying)
            //{
            //    audioSrc.Play();
            //}
        }
    }
}
