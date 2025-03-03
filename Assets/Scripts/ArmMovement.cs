using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{

    private PlayerMovement playerMovement;
    public Animator animator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var right = false; var up = false; var down = false; var left = false;
        if (angle <= 135 & angle >= 45)
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
}
