using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private int damage = 10;
    public Rigidbody2D player;
    public HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthBar.TakeDamage(damage);

            player.velocity = new Vector2(player.velocity.x, 7f);
        }
    }
}
