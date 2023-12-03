using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    public static event Action<Predator> OnPredatorKilled;
    [SerializeField] float health, maxHealth = 3f;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the health of the predator
        health -= damageAmount;
        if (health <= 0)
        {
            // Destroy the predator if it has no health left
            Destroy(gameObject);
            OnPredatorKilled?.Invoke(this);
        }
    }   
}
