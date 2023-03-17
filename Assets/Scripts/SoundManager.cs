using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject MusicSource;
    AudioSource backmusic;

    void Awake()
    {
        MusicSource = GameObject.Find("MusicSource");
        backmusic = MusicSource.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (backmusic.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(MusicSource); //배경음악 계속 재생하게(이후 버튼매니저에서 조작
        }
    }
}
