using System.Collections;
using UnityEngine;

public class LarvaAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _speed_variety = 0.2f; // WIP отклоение назначаемой при старте скорости
    [SerializeField] private GameObject _target, me; // Объект к которому будет ползти личинка и пытаться атаковать при приближении
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement_direction;
    private Animator animator;
    private Health health;
    private Attack attack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        attack = GetComponent<Attack>();
        _speed += _speed_variety * Random.Range(-1,1);
        _target = GameObject.FindGameObjectWithTag("Player");
        me = this.gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (health.IsDead())
        {
            animator.SetTrigger("Die");
            return;
        }   
        movement_direction = (Vector2)_target.transform.position + _target.GetComponent<BoxCollider2D>().offset - (Vector2)transform.position; // Определяем направление движения через коллайдер цели
        sprite.flipX = movement_direction.x < 0;
        if (movement_direction.magnitude < attack._attack_distance && !attack.isAttacking) {
            attack.Detect(me);
            attack.isAttacking = true;
        }
        if(!attack.isAttacking) transform.Translate(movement_direction.normalized * _speed * Time.deltaTime, rb.transform);
    }
}
