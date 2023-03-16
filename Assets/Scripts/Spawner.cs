using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    public Vector2 createPos;

    public void LoadImage()
    {
        //Instantiate(target, createPos, Quaternion.identity, GameObject.Find("BookPanel").transform);

        GameObject obj = Instantiate(target);
        obj.transform.SetParent(GameObject.Find("BookPanel").transform, true);
        obj.transform.localPosition = createPos;
    }
}
