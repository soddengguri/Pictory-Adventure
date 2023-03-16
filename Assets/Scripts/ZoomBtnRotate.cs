using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomBtnRotate : MonoBehaviour
{
    Button zoomBtn;

    void Start()
    {
        zoomBtn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void RotateBtn()
    {
        zoomBtn.transform.rotation = Quaternion.Euler(0, 0, 20);
    }
}
