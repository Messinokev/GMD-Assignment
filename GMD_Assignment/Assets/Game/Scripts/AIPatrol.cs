using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    //agro
    [SerializeField] private Rigidbody2D player;

    [SerializeField] private float agroRange;

    //patrol
    public float walkSpeed;
    [HideInInspector] public bool mustPatrol;

    private bool mustFlip;
    public float runSpeed;
    public int damage;

    public Rigidbody2D rb;

    public Transform groundCheckPosition;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Animator animator;
    public HealthBar healthBar;

    private static readonly int MustPatrol = Animator.StringToHash("MustPatrol");

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < agroRange)
        {
            mustPatrol = false;
        }
        else
        {
            mustPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        mustFlip = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);


        if (mustPatrol)
        {
            animator.SetBool(MustPatrol, true);
            Patrol();
        }
        else
        {
            animator.SetBool(MustPatrol, false);
            ChasePlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthBar.TakeDamage(damage);
            player.AddForce(Vector2.up *13, ForceMode2D.Impulse);

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
}