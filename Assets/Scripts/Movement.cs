using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    CharacterController controller;

    Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
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

        /*
        // 20 units per square
        if (Input.GetAxis("Vertical") > 0)
            vdir = 20.0f;
        else if (Input.GetAxis("Vertical") < 0)
            vdir = -20.0f;

        if (Input.GetAxis("Horizontal") > 0)
            hdir = 20.0f;
        else if (Input.GetAxis("Horizontal") < 0)
            hdir = -20.0f;
        */

        Vector3 movedir = new Vector3(hdir, 0, vdir);
        movedir = transform.TransformDirection(movedir);
        controller.Move(movedir);
    }
}