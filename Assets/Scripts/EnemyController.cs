using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die animation
        animator.SetBool("isDead", true);
        //Disable enemy

        Debug.Log("Enemy Died.");

        //GetComponent<Collider2D>().enabled = false;
        gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
        this.enabled = false;
        Destroy(gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
