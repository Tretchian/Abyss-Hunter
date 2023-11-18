using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaAI : MonoBehaviour
{
    // ДА, комментарии есть только там где это и так очевидно, ДА потом поправлю (может быть)
    public float speed = 1f;
    public float speed_variety = 0.2f; // WIP
    public GameObject target; // Объект к которому будет ползти личинка и пытаться атаковать при приближении
    public float attack_coolDown = 0.4f; // время между атаками в секундах 
    public float attack_distance = 3f; // WIP расстояние на котором будет пытаться атаковать
    public float damage = .4f;// Урон наносимый при атаке

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement_direction;
    private Animator animator;
    private bool attackOnCoolDown = false;
    private Health health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        speed += speed_variety * Random.Range(-1,1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health.IsDead())
        {
            animator.SetTrigger("Die");
            return;
        }
        movement_direction = target.transform.position - transform.position; //WIP переделать чтобы целью был не центр трансформа цели, а центр хитбокса цели
        sprite.flipX = movement_direction.x < 0;
        if (movement_direction.magnitude < attack_distance) {
            Attack(); 
        } else {
            
        transform.Translate(movement_direction.normalized * speed*Time.deltaTime, rb.transform);
        }

    }
    void Attack()
    {
        if (attackOnCoolDown) return;
        animator.SetTrigger("Attack");
        attackOnCoolDown = true;
        StartCoroutine(DelayAttack());
        
    }
    private void Detect()
    {
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, attack_distance))
        {
            if (collider.GetComponentInParent<Health>().GetTag().Equals("player"))
            {
                Debug.Log(collider.name);
                collider.GetComponentInParent<Health>().Damage(damage);
            }
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attack_coolDown);
        attackOnCoolDown = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 positon = transform.position == null ? Vector2.zero : transform.position;
        Gizmos.DrawWireSphere(positon, attack_distance);
    }
}
