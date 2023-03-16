using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(Camera))]
public class SnapShotCamera : MonoBehaviour
{
    Camera snapCam;

    int resWidth = 256;
    int resHeight = 256;

    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if(snapCam.targetTexture ==null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        //snapCam.gameObject.SetActive(false);
    }

   
    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if(snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string fileName = SnapshotName();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log("SnapShot taken!");
            snapCam.gameObject.SetActive(false);
        }
    }

    string SnapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{1}*{2}_{3}.png", Application.dataPath, resWidth, resHeight, System.DateTime.Now.ToString("yyyy_MM_dd_HH-mm-ss"));
    }
}
