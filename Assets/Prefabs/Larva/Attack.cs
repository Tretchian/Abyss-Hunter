using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Playables;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _attack_coolDown = 0.4f; // Время между атаками в секундах
    [SerializeField] private float _attack_distance = 1f; // Расстояние на котором будет пытаться атаковать
    [SerializeField] private float _attack_damage = .4f; // Урон наносимый при атаке
    [SerializeField] private float _collision_damage = .4f; // Урон наносимый при столкновении
    [SerializeField] private float _collision_damage_cooldown = .4f; // Интервал урона при столкновении в секундах
    [SerializeField] private bool attackOnCoolDown = false;
    [SerializeField] private bool collisionDamageOnCoolDown = false;

    private Collider2D col;
    private Animator animator;
    private GameObject Target_Unit, colliding_with;
    private Collider2D[] results = new Collider2D[1];
    private ContactFilter2D filter = new ContactFilter2D();
    public float GetAttackDistance => _attack_distance;
    public bool IsAttacking => attackOnCoolDown;
    void Start()
    {
        animator = GetComponent<Animator>();
        col = gameObject.GetComponent<Collider2D>();
    }
    void Update()
    {
        Detect_Collision();
    }
    public void AttackUnit()
    {
        if (attackOnCoolDown) return;
        attackOnCoolDown = true;
        animator.SetTrigger("Attack");
        Detect_In_Attack_Range();
        StartCoroutine(EndAttack());
    }
    private void Detect_In_Attack_Range()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _attack_distance))
        {
            if (collider.gameObject.tag == "Player")
            {
                Target_Unit = collider.gameObject;
                Target_Unit.GetComponent<Health>().DealDamage(_attack_damage);
                // Debug.Log("Attacking " + Target_Unit);
            }
        }
        Target_Unit = null;
    }
    private void Detect_Collision()
    {
        results = new Collider2D[1];
        colliding_with = null;
        int resultsAmount = col.OverlapCollider(filter.NoFilter(), results);
        if (resultsAmount > 0 && !collisionDamageOnCoolDown)
        {
            collisionDamageOnCoolDown = true;
            foreach (Collider2D collider in results)
            {
                if (collider.gameObject.tag == "Player")
                {
                    colliding_with = collider.gameObject;
                    colliding_with.GetComponent<Health>().DealDamage(_collision_damage);
                }
            }
            StartCoroutine(EndCollisionDamage());
        }
    }
    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(_attack_coolDown);
        attackOnCoolDown = false;
    }
    private IEnumerator EndCollisionDamage()
    {
        yield return new WaitForSeconds(_collision_damage_cooldown);
        collisionDamageOnCoolDown = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector2 positon = transform.position == null ? Vector2.zero : transform.position;
        Gizmos.DrawWireSphere(positon, _attack_distance);
    }
}
