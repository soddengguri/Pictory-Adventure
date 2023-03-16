using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaterViewCam : MonoBehaviour
{
    [SerializeField]
    public Vector3 offset;
    public Transform player;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = player.position + offset;
    }
}
