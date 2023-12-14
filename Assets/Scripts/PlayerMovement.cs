using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement_direction;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    public float speed = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        movement_direction.x = Input.GetAxis("Horizontal");
        movement_direction.y = Input.GetAxis("Vertical");
        sprite.flipX = movement_direction.x < 0;
        transform.Translate(movement_direction.normalized * speed * Time.deltaTime, rb.transform);
    }
}
