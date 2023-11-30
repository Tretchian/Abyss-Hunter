using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);

        Vector3 input = new Vector3(horizontalInput, verticalInput, 0);
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontalInput, verticalInput, 0);
        rb.MovePosition(transform.position + input * Time.fixedDeltaTime * 8);


    }

}