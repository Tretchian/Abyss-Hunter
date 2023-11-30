using Unity.VisualScripting;
using UnityEngine;

public class Emptypede_headAI : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Health health;
    private Rigidbody2D rb;
    public GameObject[] bodyparts;
    [SerializeField] private GameObject body_prefab;
    [SerializeField] private int length = 5;

    private Vector2 movement_direction = Vector2.left;
    
    void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        bodyparts = new GameObject[length];
      
    }

    void FixedUpdate()
    {
     
    }

    private void CreateBodyPart(GameObject target_object,int id)
    {
        GameObject new_part = body_prefab;
        Emptypede_body body_script = new_part.GetComponent<Emptypede_body>();
        body_script.speed = _speed;
        body_script.next_bodypart = target_object;
        body_script._id = id;
        bodyparts[id] = new_part;
        Instantiate(new_part);
    }
}
