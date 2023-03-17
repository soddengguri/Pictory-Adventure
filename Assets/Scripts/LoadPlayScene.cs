using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayScene : MonoBehaviour
{
    public void Move()
    {
        Invoke("SceneChange", 0f);  // 2초 뒤 
        //Destroy(GameObject.Find("MusicSource").GetComponent<SoundManager>().MusicSource);
        Destroy(GameObject.Find("MusicSource"));
        Destroy(GameObject.FindGameObjectWithTag("Music"));
        Debug.Log("Play씬으로 전환");
    }

    //"Play"씬 로드
    public void SceneChange()
    {
        SceneManager.LoadScene("Play");
        //Destroy(GameObject.Find("MusicSource").GetComponent<SoundManager>().MusicSource);
    }

}
