using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get { return currentHealth; } }
    public int maxHealth;
    private int currentHealth;

    public CharacterController2D controller;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Animator animator;

    public static bool playerHasDied = false;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {

        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        TakeDamage(amount);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            this.enabled = false;
            playerCombat.enabled = false;
            playerMovement.enabled = false;
            controller.enabled = false;
            playerHasDied = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth + damage, 0, maxHealth);

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}