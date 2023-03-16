using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    public GameObject image;

    private void Start()
    {

        Texture[] album = Resources.LoadAll<Texture>("Snapshots");

        for (int i = 0; i < album.Length; i++)
        {
            image.GetComponent<RawImage>().texture = album[i];
        }

    }
}