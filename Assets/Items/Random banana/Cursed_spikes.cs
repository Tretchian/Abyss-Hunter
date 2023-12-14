using UnityEngine;

public class Cursed_spikes : MonoBehaviour,Active_item
{
   public bool isUsed = false;
   void Start()
    {
        
    }
    void Update()
    {
        if(isUsed)Debug.Log(transform.name);   
    }
    void Active_item.pickup()
    {
        isUsed=true;
    }
    
}
