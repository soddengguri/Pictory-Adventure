using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCam2 : MonoBehaviour
{
    public Image foundImg;
    public GameObject questItem;
    public Camera cam;

    bool isExit = false;

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    void Start()
    {
      //foundImg = gameObject.GetComponent<Image>();
    }

    void Update()
    {
      
        var targetRender = questItem.GetComponent<SpriteRenderer>();

        if (IsVisible(cam, questItem) && isExit == false)
        {
            //Debug.Log(questItem + "보임");
            foundImg.gameObject.SetActive(true);
        }

        else
        {
            foundImg.gameObject.SetActive(false);
            //Debug.Log(questItem + "안 보임");
        }
        
        }
        
    }
