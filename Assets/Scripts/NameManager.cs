using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameManager : MonoBehaviour
{
    [SerializeField]
    public InputField inputName; //string, 플레이어 이름 입력칸 

    public void Save()
    {
        PlayerPrefs.SetString("PlayerName", inputName.text);
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            Debug.Log("저장");
            Destroy(GameObject.Find("MusicSource"));
            SceneManager.LoadScene("Play");
        }

    }
}
