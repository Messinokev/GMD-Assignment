using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask groundLayer;

    [SerializeField] private GameObject running;
    [SerializeField] private GameObject idle;

    private float horizontal;

    private float speed = 8f;

    private float jumpingPower = 11f;

    private bool isFacingRight = true;

    private void Start()
    {
        running.SetActive(false);
        idle.SetActive(true);
    }

    void Update()
    {
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
        }
/*
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1f);
        }*/
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
        running.SetActive(true);
        idle.SetActive(false);
        horizontal = context.ReadValue<Vector2>().x;
    }
}
