using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeReference] private Item_object item;
    public Stats stats = new Stats();   
    void Start()
    {
        InititalizeStats();
    }
    private void InititalizeStats()
    {
        stats._attackdmg = item._attackdmg;
        stats._attackspd = item._attackspd;
        stats._hp = item._hp;
        stats._maxhp = item._maxhp;
        stats._movementspd = item._movementspd;
    }
}
