using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI HPtext;

    public Animator animator;
    private static readonly int takeDamamge = Animator.StringToHash("take_damage");
    private static readonly int die = Animator.StringToHash("die");
    private static readonly int idle = Animator.StringToHash("idle");

    public bool dead;

    Respawn respawn;

    private void Awake()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);

        SetHPText();

        respawn = FindObjectOfType<Respawn>();
    }

    private void SetHPText()
    {
        HPtext.text = currentHealth.ToString();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            //Hurt
            animator.SetBool(takeDamamge, true);
        }
        else
        {
            //Die
            if (!dead)
            {
                animator.SetBool(die, true);
                dead = true;

                Invoke(nameof(PlayerRevive), 1.5f);
            }
        }
        SetHPText();
    }

    public void PlayerRevive()
    {
        animator.SetBool(idle, true);

        respawn.SetPlayerToSpawn();
        dead = false;

        currentHealth = (int) (maxHealth * 0.5);
        SetHealth(currentHealth);
        SetHPText();
    }
}
