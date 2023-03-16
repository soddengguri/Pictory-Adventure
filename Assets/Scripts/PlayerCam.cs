using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public SnapShotCamera snapCam;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            snapCam.CallTakeSnapshot();
        }
    }

    
}
