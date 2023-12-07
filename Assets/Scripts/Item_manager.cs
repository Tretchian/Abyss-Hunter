using System.Collections.Generic;
using UnityEngine;

public class Item_manager : MonoBehaviour
{
    [SerializeField] private float _itemPickupDistance = 1f;
    private Stats playerStats = new Stats();
    private PlayerMovement movement;
    public List<Item> items = new List<Item>();
    Vector2 player_center;
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
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
        foreach (Item item in items)
        {
            playerStats.addStats(item.stats);
        }
        movement.stats = playerStats;
    }
    
    void pickup() //WIP надо привязать метод к кнопке поднятия предмета
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(player_center, _itemPickupDistance)) {
            if (!collider || !collider.tag.Equals("Item")){
                continue;
            }
            items.Add(collider.GetComponent<Item>());
            collider.gameObject.SetActive(false);
        }
        recount();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player_center, _itemPickupDistance);
    }

}
