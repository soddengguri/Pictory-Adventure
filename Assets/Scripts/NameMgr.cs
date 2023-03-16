using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class NameMgr : MonoBehaviour
{
    public InputField inputUserName; 

   // 저장 기능
   public void Save()
    {
        CheckName();
        OnClickCreateName();
    }

    //로드 기능
    public void Load()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            inputUserName.text = PlayerPrefs.GetString("Name");
            //Debug.Log("로드");
        }
    }

    //한글, 영어만 유저이름으로 입력 가능
    private bool CheckName()
    {
        return Regex.IsMatch(inputUserName.text, "^[a-zA-Z가-힣]*$");
    }

    // 유저이름 생성
    public void OnClickCreateName()
    {
        // 한글, 영어로만 유저이름 만들었는지 체크
        if (CheckName() == false)
        {
            Debug.Log("한글, 영어만 입력이 가능합니다");
            return;
        }

        else if (CheckName() == true)
        {
            PlayerPrefs.SetString("Name", inputUserName.text);
            //Debug.Log("저장");
            SceneManager.LoadScene("Play");
        }
    }
}
