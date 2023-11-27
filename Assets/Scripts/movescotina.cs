using UnityEngine;

public class movescotina : MonoBehaviour
{
    Vector3 movement;
    Rigidbody rb;
    [SerializeField] private float _movementForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        rb.AddForce(movement.normalized*Time.deltaTime*_movementForce);
      

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * 1000);
    }
}
