// Manages players health and animations

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float damage = 4f;           // How much damage can deal
    public float currentHealth = 10f;   // Health
    public float maxHealth = 10f;       // Max health
    private Animator animator;
    public StaticScript statics;

    void Start()
    {
        // Get current health from statistics
        currentHealth = statics.GetHealth();

        animator = gameObject.GetComponent<Animator>();
    }

    // Player takes damage
    public bool TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        statics.UpdateHealth(currentHealth);    // Update statistics

        // Check if there is any health left
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Player heals
    public void Heal(float amount)
    {
        currentHealth = currentHealth + amount;
        statics.UpdateHealth(currentHealth);    // Update statistics

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Animations

    public void StartAttack()
    {
        animator.SetBool("Attack", true);
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    public void Dead()
    {
        animator.SetBool("isDead", true);
    }
}
