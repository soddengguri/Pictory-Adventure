using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgCount : MonoBehaviour
{
    public int picNumber = 0;
    public Text picCount;
    
    void Start()
    {
        picCount = GetComponent<Text>();
        //FrameBtn frameBtn = GameObject.Find("RawImage").GetComponent<FrameBtn>();
        picCount.text =  picCount.ToString();
        //GameObject.transform.Find("O_countImg");
        
    }


}
