using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check for player death
        if (currentHealth <= 0)
        {
            // Handle player death here (e.g., play animation, restart level, etc.)
            Debug.Log("Player is dead!");
        }
    }
}