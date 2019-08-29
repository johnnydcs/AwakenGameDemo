using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    CharacterController controller;

    Vector3 position = Vector3.zero;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        position = this.transform.position;
    }

    void Update()
    {
        CheckAttack();
        CheckMovement();
    }

    void CheckAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            anim.Play("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.E) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            anim.Play("Attack2");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("PowerUp1");
        }
    }

    void CheckMovement()
    {
        float vdir = 0.0f;
        float hdir = 0.0f;

        if (Input.GetKeyDown(KeyCode.W))
            vdir = 20.0f;

        else if (Input.GetKeyDown(KeyCode.S))
            vdir = -20.0f;

        if (Input.GetKeyDown(KeyCode.D))
            hdir = 20.0f;

        else if (Input.GetKeyDown(KeyCode.A))
            hdir = -20.0f;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            Debug.Log("IsAttacking, cannot move.");
        }

        else
        {
            Vector3 movedir = new Vector3(hdir, 0, vdir);
            movedir = transform.TransformDirection(movedir);
            controller.Move(movedir);
        }
    }
}