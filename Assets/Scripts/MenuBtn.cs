using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtn : MonoBehaviour
{
    public GameObject menuLayer;
    public GameObject backMenu;

    public void Menu_button()
    {
        Time.timeScale = 0; //게임 일시정지
        menuLayer.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        menuLayer.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void MenuButtonClick()
    {
        menuLayer.SetActive(true);
    }

    public void BackButtonClick()
    {
        menuLayer.SetActive(false);
    }

}
