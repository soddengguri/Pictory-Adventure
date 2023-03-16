using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelectScene : MonoBehaviour
{
    public void Move()
    {
        Invoke("SceneChange", 2f);  // 2초 뒤 
        Debug.Log("Select씬으로 전환");
    }

    //"Select"씬 로드
    public void SceneChange()
    {
        SceneManager.LoadScene("Select");
    }

}
