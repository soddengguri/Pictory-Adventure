using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FrameBtn : MonoBehaviour, IPointerClickHandler
{
    Button framBtn;
    public GameObject frameImg;
    public GameObject o_countImg;

    float clickCount = 0;
    //public int imgCount = 0;

    private void Start()
    {
        framBtn = this.transform.GetComponent<Button>();
        o_countImg = GetComponent<GameObject>();
        framBtn.onClick.AddListener(ColorChange);
    }

    void ColorChange()
    {
        frameImg.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        o_countImg.SetActive(true);
        //ImgCount call = GameObject.Find("PicCountText").GetComponent<ImgCount>();   // ImgCount 스크립트 변수 picnumber 카운트 +1
        //call.picNumber++;
        //imgCount++; // 색이 흰색으로 바뀌면 카운트 숫자 +1
        //Debug.Log(imgCount);

    }

    void OnMouseDoubleClick()
    {
        frameImg.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Debug.Log("취소");
        o_countImg.SetActive(false);
        //ImgCount call = GameObject.Find("PicCountText").GetComponent<ImgCount>(); // ImgCount 스크립트 변수 picnumber 카운트 -1
        //call.picNumber--;
        //imgCount = 0; // 색이 투명으로 바뀌면 카운트 숫자 -1
        //Debug.Log(imgCount);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((Time.time - clickCount) < 0.3f)
        {
            OnMouseDoubleClick();
            //o_countImg.SetActive(false);
            //imgCount = 0;
            //Debug.Log(imgCount);
        }
        else
        {
            clickCount = Time.time;
        }
    }
}

