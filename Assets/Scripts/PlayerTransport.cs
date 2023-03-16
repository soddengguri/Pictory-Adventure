using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransport : MonoBehaviour
{
    //public GameObject player;
    //public GameObject door_Head;
    public Camera GetCamera;
    private RaycastHit hit;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = GetCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;
                Debug.Log(objectName);
            }
        }
 
    }

    //public void Joy_Head()
    //{
    //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

    //    player.transform.position = new Vector3(82.3f, 0, -21f);
    //    Debug.Log("이동");
    //}
}
