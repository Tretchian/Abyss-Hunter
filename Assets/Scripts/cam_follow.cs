using UnityEngine;

public class cam_follow : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 rot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(target.position);
    }
}
