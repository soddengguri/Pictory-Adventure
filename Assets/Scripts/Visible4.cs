using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible4 : MonoBehaviour
{
    public GameObject targets;
    public Camera cam;


   private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach(var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Start()
    {
        targets = GameObject.FindWithTag("ITEM");
    }

    private void Update()
    {
        var targetRender = targets.GetComponent<Renderer>();

        if(IsVisible(cam, targets))
        {
            Debug.Log("보임");
            //targetRender.material.SetColor("_Color", Color.red);
        }

        else
        {
            Debug.Log("안보임");
        }
    }
}
