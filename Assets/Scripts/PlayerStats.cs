using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    [SerializeField] private float _itemPickupDistance = 1f;
    private Stats playerStats = new Stats();

    [SerializeField] private float _baseMaxhp = 5f;
    [SerializeField] private float _baseAttackspd = 1f;
    [SerializeField] private float _baseAttackdmg = 1f;
    [SerializeField] private float _baseMovementspd = 1f;
    private PlayerMovement movement;
    private Health health;
    public List<Item> items = new List<Item>();
    Vector2 player_center;
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
        recount();
       
    }
    private void Update()
    {
        player_center = (Vector2)transform.position + GetComponent<BoxCollider2D>().offset;
        pickup();
    }
    void recount()
    {
        playerStats = new Stats();
        playerStats.addStats(new Stats(_baseMaxhp,_baseAttackspd,_baseAttackdmg,_baseMovementspd));
        foreach (Item item in items)
        {
            playerStats.addStats(item.stats);
        }
        movement.speed = playerStats._movementspd;
        health._maxHealth = playerStats._maxhp;
    }
    
    void pickup() //WIP надо привязать метод к кнопке поднятия предмета
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(player_center, _itemPickupDistance)) {
            if (!collider || !collider.tag.Equals("Item")){
                continue;
            }
            items.Add(collider.GetComponent<Item>());
            collider.transform.GetChild(2).GetComponent<Active_item>().pickup();
            collider.transform.GetChild(2).SetParent(transform);
           
            collider.gameObject.SetActive(false);
        }
        recount();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
       .. Gizmos.DrawWireSphere(player_center, _itemPickupDistance);
    }

}
