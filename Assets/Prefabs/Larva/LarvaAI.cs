using System.Collections;
using UnityEngine;

public class LarvaAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _speed_variety = 0.2f; // WIP
    [SerializeField] private GameObject _target; // Объект к которому будет ползти личинка и пытаться атаковать при приближении
    [SerializeField] private float _attack_coolDown = 0.4f; // время между атаками в секундах 
    [SerializeField] private float _attack_distance = 3f; // WIP расстояние на котором будет пытаться атаковать
    [SerializeField] private float _damage = .4f;// Урон наносимый при атаке
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement_direction;
    private Animator animator;
    private bool attackOnCoolDown = false;
    private bool isAttacking = false;
    private Health health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        _speed += _speed_variety * Random.Range(-1,1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health.IsDead())
        {
            animator.SetTrigger("Die");
            return;
        }
        movement_direction = _target.transform.position - transform.position; //WIP переделать чтобы целью был не центр трансформа цели, а центр хитбокса цели
        sprite.flipX = movement_direction.x < 0;
        if (movement_direction.magnitude < _attack_distance &&!isAttacking) {
            Attack(); 
        }
        if(!isAttacking) transform.Translate(movement_direction.normalized * _speed * Time.deltaTime, rb.transform);
    }
    void Attack()
    {
        if (attackOnCoolDown||isAttacking) return;
        animator.SetTrigger("Attack");
        isAttacking = true;
        attackOnCoolDown = true;
        StartCoroutine(DelayAttack());
    }
    private void AttackEnd()
    {
        if (isAttacking) isAttacking = false;
    }
    private void Detect()
    {
        foreach(Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _attack_distance))
        {
            if (collider.GetComponentInParent<Health>().GetTag().Equals("player"))
            {
                Debug.Log(collider.name);
                collider.GetComponentInParent<Health>().Damage(_damage);
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
        Gizmos.color = Color.red;
        Vector2 positon = transform.position == null ? Vector2.zero : transform.position;
        Gizmos.DrawWireSphere(positon, _attack_distance);
    }

}
