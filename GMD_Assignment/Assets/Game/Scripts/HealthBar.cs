using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;
    private static readonly int takeDamamge = Animator.StringToHash("take_damage");
    private static readonly int die = Animator.StringToHash("die");

    private bool dead;

    private void Awake()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
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
            }
        }
    }
}
