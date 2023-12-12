using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FrameBugAI : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private Health health;
    private Vector2 moveToTarget;
    private Vector2 moveRandomDirection;
    private Vector2 movement;
    private bool isStopped = false; //∆ук прекращает движение если true
 
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _stopTimeSeconds = 2f;
    [SerializeField] private float _moveTimeSeconds = 4f;
    [SerializeField][Tooltip("From 0 to 1")] private float _moveRandomness = .5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        if (target == null) target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DelayMovement());
    }

    void FixedUpdate()
    {
        if (health.IsDead && !animator.IsUnityNull())
        {
            animator.SetTrigger("Die");
            return;
        }
        if (!isStopped)
        {
          
            movement = (moveToTarget + moveRandomDirection).normalized;//¬ектор направлени€ конечного перемещени€, непосредственно используетс€ в движении
            transform.Translate(movement*_speed*Time.deltaTime);
        }

    }
    private void OnDrawGizmos()
    {
            Gizmos.color= Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + movement) ;
    }

    private IEnumerator DelayMovement()
    {

        yield return new WaitForSeconds(_moveTimeSeconds);
        isStopped = true;
        moveRandomDirection = new Vector2(Random.Range(-_moveRandomness, _moveRandomness), Random.Range(-_moveRandomness, _moveRandomness));
        moveToTarget = (target.transform.position - transform.position).normalized; // ¬ектор направленный к target от жучка
        StartCoroutine(DelayStop());
    }
    private IEnumerator DelayStop()
    {
        

        yield return new WaitForSeconds(_stopTimeSeconds);
        isStopped = false;
        StartCoroutine(DelayMovement());
    }
}
