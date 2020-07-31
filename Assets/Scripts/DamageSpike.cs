using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpike : MonoBehaviour
{

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ChangeHealth(-1);

        }
    }
}
