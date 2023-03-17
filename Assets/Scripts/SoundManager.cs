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
        backmusic = MusicSource.GetComponent<AudioSource>(); //������� �����ص�
        if (backmusic.isPlaying) return; //��������� ����ǰ� �ִٸ� �н�
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(MusicSource); //������� ��� ����ϰ�(���� ��ư�Ŵ������� ����
        }
    }
}
