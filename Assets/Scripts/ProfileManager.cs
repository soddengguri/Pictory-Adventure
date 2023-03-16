using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public Text moneyText;
    public Image repBar;

    public void PlayerRepBar()
    {
        repBar.fillAmount = GameManager.instance.reputation * 0.01f; //최대 100으로
        Debug.Log("명성치: " + GameManager.instance.reputation);
    }

    public void PlayerMoney()
    {
        moneyText.text = GameManager.instance.money.ToString();
        Debug.Log("재화: " + GameManager.instance.money);
    }
}