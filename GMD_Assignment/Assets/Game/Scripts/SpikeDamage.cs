using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private int damage = 25;
    public Rigidbody2D player;
    private HealthBar healthBar;

    private void Start()
    {
        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !healthBar.dead)
        {
            healthBar.TakeDamage(damage);

            player.velocity = new Vector2(player.velocity.x, 7f);
        }
    }
}
