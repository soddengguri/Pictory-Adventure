using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportFade : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;

    private void Start()
    {
        sr = go.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }
}
