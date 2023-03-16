using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaterViewCam1 : MonoBehaviour
{
    private float maxDist = 50.0f;
    private float minDist = 5.0f;
    private float zoomSpeed = 1.0f;
    private float distance;

    [SerializeField]
    public Vector3 offset;
    public Transform player;

    void Start()
    {
        distance = Camera.main.GetComponent<Camera>().orthographicSize;
    }

void Update()
    {
        transform.position = player.position + offset;
        
    }

    void LateUpdate()
    {
        // 휠마우스 (PC에서만 작동) 줌인 줌아웃
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance < maxDist)
        {
            distance += zoomSpeed;
            Camera.main.GetComponent<Camera>().orthographicSize = distance;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance > minDist)
        {
            distance -= zoomSpeed;
            Camera.main.GetComponent<Camera>().orthographicSize = distance;
        }
    }
}
