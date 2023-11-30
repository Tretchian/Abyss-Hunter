using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, currentHealth;
    [SerializeField]
    private bool dead = false;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0) dead = true;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void ChangeHealth(float damage) // Изменяет текущее здоровье на damage
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            dead = true;
        }
    }
    public bool IsDead()
    {
        return dead;
    }
}
