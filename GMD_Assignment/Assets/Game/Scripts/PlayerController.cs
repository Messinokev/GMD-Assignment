using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask groundLayer;
    public Animator animator;

    private float horizontal;

    [SerializeField] private float speed = 8f;

    [SerializeField]  private float jumpingPower = 12f;

    private bool isFacingRight = true;
    

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");


    private void Start()
    {
        
    }

    void Update()
    {
       

        //Flipping the player
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool(IsJumping, true);
        }
        else
        {
            animator.SetBool(IsJumping, false);
        }
    }

    

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        animator.SetFloat(Speed, Mathf.Abs(horizontal));
    }
}
