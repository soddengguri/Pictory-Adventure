using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VileageEnter : MonoBehaviour
{
    public string bgmName = "";

    //private GameObject CamObject;
    private GameObject PlayerObject;

    void Start()
    {
        PlayerObject = GameObject.Find("Player_2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PlayerObject.GetComponent<PlayMusicOperator>().PlayBGM(bgmName);

        Debug.Log("Ãæµ¹");
    }
}
