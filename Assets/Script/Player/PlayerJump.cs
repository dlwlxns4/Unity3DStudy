using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody playerRigidbody;
    PlayerInput playerInput;
    Animator animator;
    bool canJump;
    [SerializeField]
    float jumpPower = 4f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
        if (canJump == false)
        {
            animator.SetFloat("JumpVelocity", -playerRigidbody.velocity.y);
        }
        VelocityControl();
    }

    void Jump()
    {
        if (canJump == false)
        {
            return;
        }

        if (playerInput.jumpInput == true)
        {
            playerRigidbody.velocity = new Vector3(0, jumpPower, 0);

            canJump = false;
            animator.SetBool("IsJump", true);

        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.GetContact(0).normal.y >= 0.85f)
        {
            animator.SetBool("IsJump", false);
            canJump = true;
        }
    }

    void VelocityControl()
    {
        if(playerRigidbody.velocity.y <= -8f)
        {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, -8f, playerRigidbody.velocity.z);
        }
    }
}
