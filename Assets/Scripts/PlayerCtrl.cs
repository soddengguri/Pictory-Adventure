using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public DialogManager dialogManager;
    private Rigidbody playerRigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Animation anim;
    Vector3 dirVec;
    //GameObject scanObject;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        //Translate(이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        //물리적 가속도 0으로 만들어 다른 오브젝트에 부딪혀도 밀리지 않음
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero; 

        //좌우방향키
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1; //스프라이트좌우대칭
            animator.SetBool("SideWalking", true);
            //dirVec = Vector3.back;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("SideWalking", false);
        }

        //위쪽방향키
        if (Input.GetButtonDown("Vertical"))
        {
            if (v >= 0.0f)
            {
                animator.SetBool("BackWalking", true);
            }
            else if (v < 0.0f)
            {
                animator.SetBool("FrontWalking", true);
            }

            dirVec = Vector3.back;
        }

        if (Input.GetButtonUp("Vertical"))
        {
            if (v >= 0.0f)
            {
                animator.SetBool("BackWalking", false);
            }
            if (v <= 0.0f)
            {
                animator.SetBool("FrontWalking", false);
            }
        }

        //물체 스캔
        //if(Input.GetButtonDown("Jump") && scanObject != null)
        //{
        //    Debug.Log("This is: " + scanObject.name);
        //}

    }

    private void FixedUpdate()
    {
        //Ray
        //Debug.DrawRay(playerRigidbody.position, dirVec * -0.7f, new Color(0, 1, 0));
        //RaycastHit rayHit = Physics.Raycast(playerRigidbody.position, dirVec, 0.7f, LayerMask.GetMask("Scan1"));

        //if (rayHit.collider != null)
        {
            //scanObject = rayHit.collider.gameObject;
        }
       // else
        {
           // scanObject = null;
        }
    }
}
