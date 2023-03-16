using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FrameBtn : MonoBehaviour, IPointerClickHandler
{
    Button framBtn;
    public GameObject frameImg;

    float clickCount = 0;
    public int imgCount = 0;

    private void Start()
    {
        framBtn = this.transform.GetComponent<Button>();
        framBtn.onClick.AddListener(ColorChange);
    }

    void ColorChange()
    {
        frameImg.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        imgCount++; // 색이 흰색으로 바뀌면 카운트 숫자 +1
        //Debug.Log(imgCount);

    }

    void OnMouseDoubleClick()
    {
        frameImg.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Debug.Log("더블클릭");

        imgCount--; // 색이 투명으로 바뀌면 카운트 숫자 -1
        //Debug.Log(imgCount);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((Time.time - clickCount) < 0.3f)
        {
            OnMouseDoubleClick();
            clickCount = -1;
        }
        else
        {
            clickCount = Time.time;
        }
    }
}

