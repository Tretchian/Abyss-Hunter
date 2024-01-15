using System;
using System.Collections;
using System.Drawing;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float _maxHealth = 5f;
    [SerializeField] private float _currentHealth;
    [SerializeField] private bool dead = false;
    [SerializeField] private float _invulnerabilityTime = 1f;
    [SerializeField] private bool invulnerable = false;
    public float GetCurrentHealth => _currentHealth;

    public event Action OnHealthChange;
    public float GetMaxHealth => _maxHealth;
    public bool IsDead => dead;
<<<<<<< HEAD
    public static event Action<GameObject> OnTakenDamage;
=======
>>>>>>> parent of 6929d52 (Merge branch 'Arsenii' into Development)
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void Update()
    {
        if (_currentHealth <= 0) dead = true;
    }
    public void DealDamage(float damage) // �������� ������� �������� �� damage
    {
        if (invulnerable)
        {
            Debug.Log("Invulnerable");
            return;
        }
        else {
            _currentHealth -= damage;
<<<<<<< HEAD

            OnTakenDamage.Invoke(transform.gameObject);
            StartCoroutine(becomeInvulnerable());
            OnHealthChange.Invoke();
            StartCoroutine(becomeInvulnerable()); 


=======
>>>>>>> parent of 6929d52 (Merge branch 'Arsenii' into Development)
            OnHealthChange.Invoke();
            StartCoroutine(becomeInvulnerable()); 
        }
        
    }
    private IEnumerator becomeInvulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(_invulnerabilityTime);
        invulnerable = false;
    }

    public void SetMaxHealth(float maxHp)
    {
       _maxHealth = maxHp;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
