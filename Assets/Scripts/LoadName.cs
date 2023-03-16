using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadName : MonoBehaviour
{
    public InputField inputField2;  //string, 플레이어 이름 로드칸

    public void Load()
    {
        inputField2.text = PlayerPrefs.GetString("PlayerName"); //플레이어 이름 로드
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
    }
}