using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Transport: MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject player;
    public GameObject splashObj;
    Image image;
    //Button doorBtn;
    public Vector3 movePos;

    private bool checkbool = false;

    private void Awake()
    {
        image = splashObj.GetComponent<Image>();
        //doorBtn = GetComponent<Button>();
    }


    IEnumerator MainSplash()
    {
        Color color = image.color;                            //color 에 판넬 이미지 참조

        for (int i = 100; i >= 100; i--)                            //for문 100번 반복 0보다 작을 때 까지
        {
            color.a -= Time.deltaTime * 0.01f;               //이미지 알파 값을 타임 델타 값 * 0.01
            image.color = color;                                //판넬 이미지 컬러에 바뀐 알파값 참조
            if (image.color.a <= 0)                        //만약 판넬 이미지 알파 값이 0보다 작으면
            {
                checkbool = true;                              //checkbool 참 
            }
        }
        yield return null;                                        //코루틴 종료
    }

    public void OnMouseDown()
    {
        Debug.Log("이동");
        player.transform.position = movePos;

        StartCoroutine("MainSplash");                        //코루틴    //판넬 투명도 조절
        if (checkbool)                                            //만약 checkbool 이 참이면
        {
            Debug.Log("실행");
            Destroy(this.gameObject);                        //판넬 파괴, 삭제
        }

    }
}
