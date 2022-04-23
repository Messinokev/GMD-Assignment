using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    //agro
    [SerializeField] private Rigidbody2D player;

    [SerializeField] private float agroRange;
    public float runSpeed;
    

    private bool mustAttack;
    private float coolDown;
    [SerializeField] private float attackRange;
    private float previousAttackTime;
    private int damage = 25;
    public HealthBar healthBar;
    

    //patrol
    public float walkSpeed;
    [HideInInspector] public bool mustPatrol;

    private bool mustFlip;

    public Rigidbody2D rb;

    public Transform groundCheckPosition;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Animator animator;

    private static readonly int MustPatrol = Animator.StringToHash("MustPatrol");
    private static readonly int MustAttack = Animator.StringToHash("MustAttack");

    void Start()
    {
        previousAttackTime = -9999f;
        coolDown = 3f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < agroRange)
        {
            if (distanceToPlayer < attackRange)
            {
                mustAttack = true;
            }
            else
            {
                mustAttack = false;
            }
            mustPatrol = false;

        }
        else
        {
            mustAttack = false;
            mustPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        mustFlip = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);


        if (mustPatrol)
        {
            animator.SetBool(MustPatrol, true);
            animator.SetBool(MustAttack, false);
            Patrol();
        }
        else
        {
            animator.SetBool(MustPatrol, false);
            if (mustAttack)
            {
                AttackPlayer();
            }
            else
            {
                animator.SetBool(MustAttack, false);
                ChasePlayer();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !healthBar.dead)
        {
            healthBar.TakeDamage(damage);
        }
    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        runSpeed *= -1;
        mustFlip = false;
    }

    private void ChasePlayer()
    {
        if (Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer))
        {
            if (player.position.x > transform.position.x && walkSpeed < 0)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && walkSpeed > 0)
            {
                Flip();
            }

            rb.velocity = new Vector2(runSpeed * Time.fixedDeltaTime, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void AttackPlayer()
    {
        if (!(Time.time > (previousAttackTime + coolDown))) return;
        animator.SetBool(MustAttack, true);
        previousAttackTime = Time.time;
    }
}