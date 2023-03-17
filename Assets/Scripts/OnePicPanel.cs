using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnePicPanel : MonoBehaviour
{
    Button coverPicBtn;
    public GameObject listedImg;
    public GameObject coverImg;
    public GameObject onePicpanel;

    private void Start()
    {
        coverPicBtn = this.transform.GetComponent<Button>();
        coverPicBtn.onClick.AddListener(OpenPanel);
        coverPicBtn.onClick.AddListener(Func);
    }

    void Func()
    {
        coverImg.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        coverImg.GetComponent<RawImage>().texture = listedImg.GetComponent<RawImage>().texture;
    }

    void OpenPanel()
    {
        onePicpanel.SetActive(true);
    }
}
