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
    public TextMeshProUGUI coinsText;

    private float horizontal;

    private float speed = 8f;

    private float jumpingPower = 11f;

    private bool isFacingRight = true;
    public static int coinCount;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");


    private void Start()
    {
        coinCount = 0;
        SetCoinsText();
    }

    void Update()
    {
        //Set coin text
        SetCoinsText();

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

    private void SetCoinsText()
    {
        coinsText.text = coinCount.ToString();
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
