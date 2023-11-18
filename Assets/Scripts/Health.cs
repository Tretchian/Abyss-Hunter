using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 5f, currentHealth = 5f;
    [SerializeField]
    private string tag;
    private bool dead = false;

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
    public void Damage(float damage)
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
    public string GetTag()
    {
        return tag;
    }
}
