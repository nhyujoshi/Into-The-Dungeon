using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            if(playerHealth.Health < playerHealth.maxHealth)
            {
                playerHealth.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
