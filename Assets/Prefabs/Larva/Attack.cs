using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _attack_coolDown = 0.4f; // время между атаками в секундах
    [SerializeField] public float _attack_distance = 1f; // расстояние на котором будет пытаться атаковать
    [SerializeField] private float _damage = .4f; // Урон наносимый при атаке
    private Animator animator;
    private bool attackOnCoolDown = false;
    public bool isAttacking = true;
    private GameObject colliding_with, attacker;
     
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void AttackUnit()
    {
        if (attackOnCoolDown || isAttacking) return;
        animator.SetTrigger("Attack");
        isAttacking = true;
        attackOnCoolDown = true;
        colliding_with.GetComponent<Health>().ChangeHealth(_damage);
        StartCoroutine(DelayAttack());
        AttackEnd();
    }
    private void AttackEnd()
    {
        if (isAttacking) isAttacking = false;
    }
    public void Detect(GameObject attackerObj)
    {
        
        attacker = attackerObj;
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(attacker.transform.position, _attack_distance))
        {
            colliding_with = collider.gameObject;
            if (colliding_with.tag == "Player" && !attackOnCoolDown)
            {
                Debug.Log(collider.name);
                AttackUnit();
                
            }
        }
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(_attack_coolDown);
        attackOnCoolDown = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector2 positon = transform.position == null ? Vector2.zero : transform.position;
        Gizmos.DrawWireSphere(positon, _attack_distance);
    }
}
