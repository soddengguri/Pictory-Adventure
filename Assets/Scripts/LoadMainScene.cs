using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
   // Main 버튼 클릭시 Main 씬으로 이동
   public void SceneChange()
    {
        SceneManager.LoadScene("Main");
    }
}
