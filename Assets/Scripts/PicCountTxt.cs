using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicCountTxt : MonoBehaviour
{
    public Text PicTxt;
    int vol = 1;

    void Start()
    {
        PicTxt.text = "0";
    }


    public void VolPlus()
    {
        vol += 1;
        PicTxt.text = vol.ToString();
    }

    public void VolMinus()
    {
        vol -= 1;
        PicTxt.text = vol.ToString();
    }
}
