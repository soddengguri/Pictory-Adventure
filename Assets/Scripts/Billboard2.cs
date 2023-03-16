using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard2 : MonoBehaviour
{
    Transform mainCam;

    void Start()
    {
        mainCam = Camera.main.transform;
    }

    void Update()
    {
        LookCam();
    }

    public void LookCam()
    {
        transform.LookAt(transform.position + mainCam.rotation * Vector3.forward, mainCam.rotation * Vector3.up);
        
    }

    public void TurnOff()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<Billboard>().enabled = false;
    }

    public void TurnOn()
    {
        gameObject.GetComponent<Billboard>().enabled = true;
        this.transform.rotation = Quaternion.Euler(21.14f, 0, 0);
    }
}
