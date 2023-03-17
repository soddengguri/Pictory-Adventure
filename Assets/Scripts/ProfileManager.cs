using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public Text moneyText_UI;
    public Text moneyText_Print;
    public Text moneyText_Profile;
    public Image repBar;

    private void Update()
    {
      // PlayerMoney_2();
    }

    public void PlayerRepBar()
    {
        repBar.fillAmount = GameManager.instance.reputation * 0.01f; //최대 100으로
        Debug.Log("명성치: " + GameManager.instance.reputation);
    }

    //public void PlayerMoney()
    //{
    //    moneyText_Profile.text = GameManager.instance.money.ToString();
    //    Debug.Log("재화: " + GameManager.instance.money);
    //}

    //public void PlayerMoney_2()
    //{
    //    moneyText_UI.text = GameManager.instance.money.ToString();
    //    //Debug.Log("재화: " + GameManager.instance.money);
    //}

    //public void PlayerMoney_3()
    //{
    //    moneyText_Print.text = GameManager.instance.money.ToString();
    //    //Debug.Log("재화: " + GameManager.instance.money);
    //}
}