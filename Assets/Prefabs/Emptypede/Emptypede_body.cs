
using UnityEngine;

public class Emptypede_body : MonoBehaviour
{
    public int _id;
    private Health health;
    public GameObject next_bodypart;
    public float speed = 1f;
    private Vector2 movement;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (next_bodypart.Equals(null)) return;
        movement = next_bodypart.transform.position - transform.position;
        transform.Translate(movement.normalized * Time.deltaTime * speed);
    }
}
