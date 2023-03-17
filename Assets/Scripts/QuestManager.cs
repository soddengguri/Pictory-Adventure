using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    public void Print_Money()//마을 시장님 
    {
        //GameManager.instance.money -= 24000;
        //Debug.Log("재화: " + GameManager.instance.money);
    }
    private void Quest1()//마을 시장님 
    {
        GameManager.instance.reputation += 5;
        Debug.Log("명성치: " + GameManager.instance.reputation);
        //Debug.Log("재화: " + GameManager.instance.money);
    }

    private void Quest2()//풍선펌프
    {
        GameManager.instance.reputation += 20;
        Debug.Log("명성치: " + GameManager.instance.reputation);
        //GameManager.instance.money += 5000;
        //Debug.Log("재화: " + GameManager.instance.money);
    }

    private void Quest3()//호두까기
    {
        GameManager.instance.reputation += 20;
        Debug.Log("명성치: " + GameManager.instance.reputation);
        //GameManager.instance.money += 5000;
        //Debug.Log("재화: " + GameManager.instance.money);
    }

    private void Quest4()//마술사토끼
    {
        GameManager.instance.reputation += 20;
        Debug.Log("명성치: " + GameManager.instance.reputation);
        //GameManager.instance.money += 5000;
       //Debug.Log("재화: " + GameManager.instance.money);
    }
}
