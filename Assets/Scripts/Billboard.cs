using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Billboard : MonoBehaviour
{
    Transform mainCam;
    public Transform getRotY;
    GameObject[] plants;
    GameObject ballon;

    void Start()
    {
;       mainCam = Camera.main.transform;
        plants = GameObject.FindGameObjectsWithTag("Billboard");
        ballon = GameObject.FindGameObjectWithTag("Ballon");

    }

    void Update()
    {
        LookCam();
        LookCam2();
    }

    public void LookCam() // 모든 빌보드 필요한 오브젝트
    {
        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].transform.LookAt(plants[i].transform.position + mainCam.rotation * Vector3.forward, mainCam.rotation * Vector3.up);        
        }

    }

    public void LookCam2() // Joy 건물 위 풍선 
    {
        ballon.transform.rotation = Quaternion.Euler(0, getRotY.transform.rotation.eulerAngles.y, 0);
    }

    public void TurnOff()
    {
        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].transform.rotation = Quaternion.Euler(0, getRotY.transform.rotation.eulerAngles.y, 0);
        }
        gameObject.GetComponent<Billboard>().enabled = false;
        //Debug.Log(getRotY.transform.rotation.eulerAngles.y);
    }

    public void TurnOn()
    {
        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].transform.LookAt(plants[i].transform.position + mainCam.rotation * Vector3.forward, mainCam.rotation * Vector3.up);
        }
        gameObject.GetComponent<Billboard>().enabled = true;
    }
}