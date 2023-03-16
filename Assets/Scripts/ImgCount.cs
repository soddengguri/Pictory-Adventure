using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgCount : MonoBehaviour
{
    public Text picCount;
    
    void Start()
    {
        FrameBtn frameBtn = GameObject.Find("RawImage").GetComponent<FrameBtn>();
        picCount.text = frameBtn.imgCount.ToString();
    }

    
    void Update()
    {
        
    }
}
