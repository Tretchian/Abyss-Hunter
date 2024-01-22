using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class MoldenLarvaAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _speed_variety = 0.2f; // WIP
    [SerializeField] private GameObject _target; // Объект к которому будет ползти личинка и пытаться атаковать при приближении

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement;
    private Animator animator;
    private Health health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        _speed += Random.Range(-_speed_variety, _speed_variety);
        if(_target == null) _target = GameObject.FindGameObjectWithTag("Player");
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (health.IsDead && !animator.IsUnityNull())
        {
            animator.SetTrigger("Die");
            return;
        }
            transform.Translate(movement.normalized * _speed * Time.deltaTime);
        sprite.flipX = movement.x < 0;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Wall"))
        {
            movement = new Vector2(Random.Range(-2f,2f),Random.Range(-2f,2f)) + -movement.normalized;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + movement);
    }
}
