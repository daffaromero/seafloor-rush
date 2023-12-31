using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    public static event Action<Predator> OnPredatorKilled;
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] HealthbarScript healthbar;
    private void Awake()
    {
        LogicScript.Instance.AddPredatorToList(this);
        healthbar = GetComponentInChildren<HealthbarScript>();
    }

    void Start()
    {
        health = maxHealth;
        healthbar.UpdateHealthBar(health, maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the health of the predator
        health -= damageAmount;
        healthbar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            // Destroy the predator if it has no health left
            Destroy(gameObject);
            OnPredatorKilled?.Invoke(this);
        }
    }
    
    public void GetInked(bool isInked)
    {
        if (isInked)
        {
            // Disable collisions with the predator
            GetComponent<Collider2D>().enabled = false;
            // Reduce the opacity of the predator
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
