using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamCtrl : MonoBehaviour
{
    public Transform centralAxis;
    public Transform cam;
    public float camSpeed;
    public float zoomSpeed;
    float mouseX;
    float mouseY = 0;
    float wheel= 0.6f;

    Vector3 movement;

    public Transform playerAxis;
    public Transform player;

    public float distance = 3;

    public GameObject menuPopup;

    void CamMove()
    {
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            
            centralAxis.rotation = Quaternion.Euler(new Vector3(centralAxis.rotation.x + mouseY, centralAxis.rotation.y + mouseX, 0) * camSpeed);
        }
    }

    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel");

        if (wheel >= 1.4f) // 최대 줌아웃
        {
            wheel = 1.4f;
        }

        if (wheel <= 0.4f) //최대 줌인
        {
            wheel = 0.4f;
        }

        cam.localPosition = new Vector3(0, 4.3f, -6.75f) * wheel;
    }

    //public void TurnOffZoom()
    //{
    //    Zoom(false);
    //    Debug.Log("줌 꺼짐");
    //}

    //public void TurnOnZoom()
    //{
    //    Zoom(true);
    //    Debug.Log("줌 켜짐");
    //}


    void Update()
    {
        CamMove();
        Zoom();
        //if (menuPopup.activeSelf == true)
        //{
        //    Zoom(false);
        //}
        //else if (menuPopup.activeSelf == false)
        //{
        //    Zoom(true);
        //}
    }

    private void LateUpdate()
    {
        // 카메라 중심축이 플레이어 따라다니기
        centralAxis.position = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
    }
}
