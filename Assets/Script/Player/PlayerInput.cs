using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Movement
    public float xInput{get;set;}
    public float yInput{get;set;}
    public bool jumpInput{get;set;}
    public bool attackInput{get;set;}

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        jumpInput = Input.GetButton("Jump");
        attackInput = Input.GetButtonDown("Attack");
    }
}
