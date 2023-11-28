using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emptypede_headAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Health health;
    private Rigidbody2D rb;
    private GameObject[] bodyparts;
    [SerializeField] private GameObject body_prefab;
    [SerializeField] private int length = 3;

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

    private void CreateBodyPart(GameObject target_object,int id)
    {
        GameObject new_part = body_prefab;
        Emptypede_body body_script = new_part.GetComponent<Emptypede_body>();
        body_script.speed = _speed;
        body_script.next_bodypart = target_object;
        body_script._id = id;
        bodyparts.SetValue(new_part, id);
        Instantiate(new_part);
    }
}
