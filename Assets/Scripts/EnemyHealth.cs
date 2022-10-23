// Manages enemys health and animations

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float damage = 3f;           // How much can deal damage
    public float currentHealth = 5f;    // Health
    public float maxHealth = 5f;        // Max health
    public HealthBarEnemy bar;          // Health bar
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // When enemy get hit
    public bool TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        bar.Damage(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

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
        Destroy(gameObject);
    }
}
