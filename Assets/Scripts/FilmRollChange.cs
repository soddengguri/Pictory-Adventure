using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmRollChange : MonoBehaviour
{
    public GameObject[] filmObj;
    int num;

    private void Start()
    {
        num = 0;
    }

    public void Next()
    {
        

        for(int i = 0; i < filmObj.Length; i++)
        {
            if (num < filmObj.Length)
            {
                filmObj[i].gameObject.SetActive(false);
                filmObj[num].gameObject.SetActive(true);
            }
            else if (num >= filmObj.Length)
            {
                num = 0;
            }
        }


        num += 1;

        if (num >= filmObj.Length)
        {
            num = 0;
            filmObj[num].gameObject.SetActive(true);
        }

        Debug.Log("num:" + num);

    }

    public void Previous()
    {
        num -= 1;

        if (num < 0)
        {
            num = Mathf.Abs(filmObj.Length);
        }

        for (int i = 0; i < filmObj.Length; i++)
        {
            if(num <= filmObj.Length)
            {
                filmObj[i].gameObject.SetActive(false);
                filmObj[num].gameObject.SetActive(true);
            }
            else if(num < 0)
            {
                num = Mathf.Abs(filmObj.Length);
            }
            
        }
        Debug.Log("num:" + num);
    }

    public void Resetnum()
    {
        num = 0;
    }
}
