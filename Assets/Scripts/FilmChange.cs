using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmChange : MonoBehaviour
{
    public GameObject[] filmObj;
    int num;

    private void Start()
    {
        num = 0;
    }

    private void Update()
    {
        if (num >= 7);
        {
            num = 7;
        }

        if(num < 0)
        {
            num = 0;
        }

        if(num == 0)
        {
            filmObj[0].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        num += 1;

        for(int i = 0; i < filmObj.Length; i++)
        {
            filmObj[i].gameObject.SetActive(false);
            filmObj[num].gameObject.SetActive(true);
        }
        Debug.Log(num);
    }

    public void Previous()
    {
        num -= 1;
        for(int i = 0; i < filmObj.Length; i++)
        {
            filmObj[i].gameObject.SetActive(false);
            filmObj[num].gameObject.SetActive(true);
        }
        Debug.Log(num);
    }
}
