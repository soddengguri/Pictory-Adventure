using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookVolumeTxt : MonoBehaviour
{
    public Text VolumeTxt;
    int vol = 1;

    void Start()
    {
        VolumeTxt.text = "1";
    }


    public void VolPlus()
    {
        vol += 1;
        VolumeTxt.text = vol.ToString();
    }

    public void VolMinus()
    {
        vol -= 1;
        VolumeTxt.text = vol.ToString();
    }
}
