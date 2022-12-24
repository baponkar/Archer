using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;

    [Header("Hand Arrow")]
    public GameObject handArrow;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        handArrow.gameObject.SetActive(false);
    }

    public void  HandArrowActivate()
    {
        handArrow.gameObject.SetActive(true);
    }

    public void HandArrowDeactivate()
    {
        handArrow.gameObject.SetActive(false);
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("xSpeed", x);
        animator.SetFloat("ySpeed", y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        if(Input.GetButton("Fire1"))
        {
            animator.SetBool("aim", true);
        }

        if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }
}
