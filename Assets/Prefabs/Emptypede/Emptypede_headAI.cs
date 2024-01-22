using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Emptypede_headAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Health health;
    private Rigidbody2D rb;
    private Dictionary<int, Vector2> directions = new Dictionary<int, Vector2>()
    {
        {1, Vector2.up },
        {2, Vector2.down },
        {3, Vector2.left },
        {4, Vector2.right }
    };
    public Vector2 movement_direction = Vector2.left;
    private Vector2 old_direction = Vector2.right;
    void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.Translate(movement_direction.normalized*_speed*Time.deltaTime,transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SelectDirection();
        }
    }
    private void SelectDirection()
    {
        old_direction = movement_direction;
        movement_direction = directions[Random.Range(1, 5)];
        while (movement_direction == old_direction)
        {
            movement_direction = directions[Random.Range(1, 5)];
        }
    }
}
