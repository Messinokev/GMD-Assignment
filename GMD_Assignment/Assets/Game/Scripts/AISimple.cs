using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISimple : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;

    [SerializeField] private float agroRange;
    public float runSpeed;
    
    public float walkSpeed;
    [HideInInspector] public bool mustPatrol;

    private bool mustFlip;

    public Rigidbody2D rb;

    public Transform groundCheckPosition;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Animator animator;
    private static readonly int MustWalk = Animator.StringToHash("MustWalk");
    
    private HealthBar healthBar;
    private int damage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        mustPatrol = !(distanceToPlayer < agroRange);
    }

    private void FixedUpdate()
    {
        mustFlip = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        if (mustPatrol)
        {
            animator.SetBool(MustWalk, true);
            MoveAround(walkSpeed);
        }
        else
        {
            animator.SetBool(MustWalk, false);
            MoveAround(runSpeed);
        }
    }
    
    void MoveAround(float moveSpeed)
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        runSpeed *= -1;
        mustFlip = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !healthBar.dead)
        {
            healthBar.TakeDamage(damage);
        }
    }
}
