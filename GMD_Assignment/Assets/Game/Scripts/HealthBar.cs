using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth;
    public int currentHealth;
    private TextMeshProUGUI HPtext;

    public Animator animator;
    private static readonly int takeDamamge = Animator.StringToHash("take_damage");
    private static readonly int die = Animator.StringToHash("die");
    private static readonly int idle = Animator.StringToHash("idle");

    public bool dead;

    Respawn respawn;


    private void Start()
    {
        HPtext = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();

        SetHPText(currentHealth);

        respawn = FindObjectOfType<Respawn>();
    }

    private void FixedUpdate()
    {
        if (animator == null)
        {
            animator = GameObject.Find("Player").GetComponent<Animator>();
        }
        if (respawn == null)
        {
            respawn = GetComponent<Respawn>();
        }
        SetHPText(currentHealth);
    }

    private void SetHPText()
    {
        HPtext.text = currentHealth.ToString();
    }

    private void SetHPText(int currentHealth)
    {
        HPtext.text = currentHealth.ToString();
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
                dead = true;
                animator.SetBool(die, true);
                    
                Invoke(nameof(PlayerRevive), 1.35f);

                currentHealth = 0;
            }
        }
        SetHPText();
    }

    public void AddHealth(int healing)
    {
        currentHealth += healing;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        SetHealth(currentHealth);
        SetHPText();
    }

    public void PlayerRevive()
    {
        animator.SetBool(idle, true);

        respawn.SetPlayerToSpawn();
        dead = false;

        currentHealth = (int)(maxHealth * 0.5);
        SetHealth(currentHealth);
        SetHPText();
    }
}
