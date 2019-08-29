using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
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
        
    }
}
