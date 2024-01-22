using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement_direction;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Animator animator;
    
    public float speed = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var right = false; var up = false; var down = false; var left = false;
        if (angle <= 135 & angle >=45)
        {
            up = true;
        }
        if (angle <= -135 || angle > 135)
        {
            left = true;
        }
        if (angle > -135 & angle <= -45)
        {
            down = true;
        }
        if (angle > -45 & angle < 45)
        {
            right = true;
        }
        animator.SetBool("up", up);
        animator.SetBool("down", down);
        animator.SetBool("right", right);
        animator.SetBool("left", left);
    }
    private void FixedUpdate()
    {
        movement_direction.x = Input.GetAxis("Horizontal");
        movement_direction.y = Input.GetAxis("Vertical");
        //sprite.flipX = movement_direction.x < 0;
        transform.Translate(movement_direction.normalized * speed * Time.deltaTime, rb.transform);

        var move = false;
        if (movement_direction.x != 0 || movement_direction.y != 0)
        {
            move = true;
        }
        animator.SetBool("move", move);
    }
}
