using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuPopupLocation : MonoBehaviour
{
    public RectTransform pos;

   
    void Start()
    {
        pos = GetComponent<RectTransform>();
    }


    void Update()
    {
       
    }

    public void Move()
    {
        pos.anchoredPosition = new Vector2(0, 3500);
    }

    public void MoveBack()
    {
        pos.anchoredPosition = new Vector2(0, 0);
    }
}

