using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        Debug.Log("보임" + Camera.current.name);
    }

    private void OnBecameInInvisible()
    {
        Debug.Log("안보임");
    }
}
