using UnityEngine;
using System;

public class Cursed_spikes : MonoBehaviour,Active_item
{
   public bool isUsed = false;
   void Start()
    {
        
    }
    void Update()
    {
       
    }
    void Active_item.pickup()
    {
        isUsed=true;
    }
    private void OnEnable()
    {
        Health.OnTakenDamage += Health_OnTakenDamage;
    }
    private void OnDisable()
    {
        Health.OnTakenDamage -= Health_OnTakenDamage;
    }
    private void Health_OnTakenDamage(GameObject obj)
    {
        if (isUsed &&obj && obj.tag.Equals("Player"))
        {
            Debug.Log("PLayer is damaged");
        } //если obj c тегом игрока получил урон
    }
}
