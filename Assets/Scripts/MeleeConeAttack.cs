using UnityEngine;
using HilamGhostPrototypes;
using System;
using System.Collections;
public class MeleeConeAttack : MonoBehaviour
{
    [SerializeField] Transform originGO;
    [SerializeField] float maxDistance;
    [SerializeField, Range(0, 120)] float angle;
    [SerializeField] private float _attack_coolDown = 0.4f;
    [SerializeField] private bool attackOnCoolDown = false;

    [SerializeField] float MouseAngle;

    [SerializeField] Collider2D[] pointedObjects;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] float Damage = 1f;
    [SerializeField] Vector3 mousePos;

    private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = (1 << LayerMask.NameToLayer("Enemy"));
    }
    void RotatePlayer()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

    }
    void Attack() {         
        if (attackOnCoolDown) return;
        attackOnCoolDown = true;
        pointedObjects = gameObject.transform.OverlapConeAll(MouseAngle, angle, maxDistance, layerMask);
        foreach (Collider2D collider in pointedObjects)
        {
            Debug.Log("Attacking " + collider.gameObject);
            collider.gameObject.GetComponent<Health>().DealDamage(Damage);
        }
        pointedObjects = null;
        StartCoroutine(EndAttack());
       }
    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (tag.Equals("Player"))
        {
            stats = GetComponent<PlayerStats>();
            Damage = stats.getAttackDmg;
        }
    }
    private void OnDrawGizmosSelected()
    {
        gameObject.transform.VisualizeConeWithGizmos(MouseAngle, angle, maxDistance, Color.white);
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, mousePos);
        Gizmos.DrawSphere(mousePos, 0.1f);
        Console.WriteLine("MousePos: " + mousePos);
    }
    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(_attack_coolDown);
        attackOnCoolDown = false;
    }
}
