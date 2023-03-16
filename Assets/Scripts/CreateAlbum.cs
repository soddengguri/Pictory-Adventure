using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAlbum : MonoBehaviour
{
    public GameObject rawimg; //프리팹
    public Vector2 createPos; //생성 위치

    public void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(rawimg, createPos, Quaternion.identity, GameObject.Find("Contents").transform);
        }

    }
}
