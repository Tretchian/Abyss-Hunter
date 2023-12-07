using System.Collections;
using UnityEngine;

public class LarvaAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f; // ������� �������� ������������
    [SerializeField] private float _speed_variety = 0.2f; // WIP ��������� ����������� ��� ������ ��������
    [SerializeField] private GameObject _target; // ������ � �������� ����� ������ ������� � �������� ��������� ��� �����������
    
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
        _speed += _speed_variety * Random.Range(-1,1); // �������� ������� ����� ���������� �� ������� �� _speed_variety
        _target = GameObject.FindGameObjectWithTag("Player"); // ����� ����� ������ � ����� "Player"
    }
    void FixedUpdate()
    {
        if (health.IsDead)
        {
            animator.SetTrigger("Die");
            return;
        }   
        movement_direction = (Vector2)_target.transform.position + _target.GetComponent<BoxCollider2D>().offset - (Vector2)transform.position; // ���������� ����������� �������� ����� ��������� ����
        sprite.flipX = movement_direction.x < 0; // ���� ����������� �������� �����, �� ������������� ������
        if (movement_direction.magnitude < attack.GetAttackDistance && !attack.IsAttacking) {
            attack.AttackUnit(); // ���� ���� ���������� ������, �� �������
        }
        if(!attack.IsAttacking) transform.Translate(movement_direction.normalized * _speed * Time.deltaTime, rb.transform); // ���� �� �������, ��������
    }
}
