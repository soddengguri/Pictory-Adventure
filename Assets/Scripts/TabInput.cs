using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabInput : MonoBehaviour
{
    public void TabIn()
    {
        //Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString());
        Input.GetKeyDown(KeyCode.Tab);
        Debug.Log("ÅÇ ´©¸§");
          
    }
}
