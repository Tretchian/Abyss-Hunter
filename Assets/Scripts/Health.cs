using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth = 5f;
    [SerializeField] private float currentHealth = 5f;
    [SerializeField] private string tag;
    private bool dead = false;

    private void Update()
    {
        if (currentHealth <= 0) dead = true;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
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
