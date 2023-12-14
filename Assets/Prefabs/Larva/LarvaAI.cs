using System.Collections;
using UnityEngine;

public class LarvaAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f; // Базовая скорость передвижения
    [SerializeField] private float _speed_variety = 0.2f; // WIP отклоение назначаемой при старте скорости
    [SerializeField] private GameObject _target; // Объект к которому будет ползти личинка и пытаться атаковать при приближении
    
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
        _speed += _speed_variety * Random.Range(-1,1); // Скорость личинки будет отличаться от базовой на _speed_variety
        _target = GameObject.FindGameObjectWithTag("Player"); // Задаёт целью объект с тегом "Player"
    }
    void FixedUpdate()
    {
        if (health.IsDead)
        {
            animator.SetTrigger("Die");
            return;
        }   
        movement_direction = (Vector2)_target.transform.position + _target.GetComponent<BoxCollider2D>().offset - (Vector2)transform.position; // Определяем направление движения через коллайдер цели
        sprite.flipX = movement_direction.x < 0; // Если направление движения влево, то разворачиваем спрайт
        if (movement_direction.magnitude < attack.GetAttackDistance && !attack.IsAttacking) {
            attack.AttackUnit(); // Если цель достаточно близко, то атакуем
        }
        if(!attack.IsAttacking) transform.Translate(movement_direction.normalized * _speed * Time.deltaTime, rb.transform); // Пока не атакует, движется
    }
}
