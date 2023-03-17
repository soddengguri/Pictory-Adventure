using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateAlbum : MonoBehaviour
{
    public GameObject rawimg; //프리팹
    public Vector2 createPos; //생성 위치

    public void Start()
    {
;       LoadImage();
    }

    public void LoadImage()
    {

        //AssetDatabase.Refresh();
        GameObject imgData = rawimg;

        Texture[] album = Resources.LoadAll<Texture>("Snapshots");

        for (int i = 0; i < album.Length; i++)
        {
            GameObject newObj = Instantiate(        //계속 앨범를 중복해서 새로 불러오는 이슈
            imgData, createPos, Quaternion.identity,
            GameObject.Find("Contents").transform);

            newObj.GetComponent<RawImage>().texture = album[i];
        }
    }

    public void ResourceRefresh()
    {
       // Object.Destroy(imgData);
    }
}
