using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmCamCtrl : MonoBehaviour
{

    public float zoomSpeed = 10.0f;
    public float distance;

    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void ZoomOut()
    {
        distance = 1.0f * zoomSpeed;
        if (distance != 0)
        {
            cam.fieldOfView += distance;
        }
        //Debug.Log(cam.fieldOfView += distance);
    }

    public void ZoomIn()
    {
        distance = 1.0f * -1 * zoomSpeed;
        if (distance != 0)
        {
            cam.fieldOfView += distance;
        }
        //Debug.Log(cam.fieldOfView += distance);
    }

   public void defaultZoomSetting()
    {
        cam.fieldOfView = 60;
    }

}
