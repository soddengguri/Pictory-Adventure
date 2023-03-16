using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBtnCtrl : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void Shoot()
    {
        animator.SetBool("isClicked", true);
    }
}
