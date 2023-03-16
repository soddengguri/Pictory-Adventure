using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public GameObject imageObj;

    public void Func(int num)
    {
        imageObj.GetComponent<Image>().sprite = Resources.Load("Bookcover/cover_" + num, typeof(Sprite)) as Sprite;
    }
}
