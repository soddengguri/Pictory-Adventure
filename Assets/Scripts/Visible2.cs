using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible2 : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> findlList = null;

    private Camera cam;

    void Start()
    {
        cam = UnityEngine.Camera.main;
    }

    
    void Update()
    {
        for(int i = 0; i < findlList.Count; i++)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(findlList[i].transform.position);
            if(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <=1 && viewPos.z >0)
            {
                Debug.Log($" Camera in Object : {findlList[i].name}");
            }
        }
    }
}
