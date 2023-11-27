using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emptypede_headAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Health health;
    private Rigidbody2D rb;

    private Vector2 movement_direction = Vector2.left;
    void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.Translate(movement_direction.normalized*_speed*Time.deltaTime,transform);
    }
}
