using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Visible5 : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    public GameObject questInfoImage;
    //public GameObject foundImg;
    //public Button exitBtn;
    SpriteRenderer targetRender;
    int count = 200;

    bool isExit = false;

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach(var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Start()
    {
        //exitBtn = this.GetComponent<Button>();
        //exitBtn.onClick.AddListener(exitBtnClick);
        var targetRender = target.GetComponent<SpriteRenderer>();
        //foundImg = gameObject.GetComponent<GameObject>();

    }


    private void Update()
    {
        var targetRender = target.GetComponent<SpriteRenderer>();

        if (IsVisible(cam, target) && isExit == false)
        {
            //Debug.Log(target + "보임");
            targetRender.material.color = new Color(255 / 255f, 255 / 255f, 155 / 255f); //노란색
            questInfoImage.gameObject.SetActive(true);

            //시간이 지나면 색 변함
            //targetRender.material.color = Color.Lerp(Color.yellow, Color.white, 1 - count * 0.01f);
            //count--;
            //exitBtnClick();
        }

        else
        {
            //Debug.Log(target + "안 보임");
            targetRender.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f); //흰색
            questInfoImage.gameObject.SetActive(false);
        }
    }

    //void exitBtnClick()
    //{
    //    SpriteRenderer targetRender = target.GetComponent<SpriteRenderer>();

    //    targetRender.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);

    //    isExit = true;
    //}
}

