using UnityEngine;
public class Item : MonoBehaviour
{
    //Вся суть этого скрипта сводится к переводу статов из scriptable object в stats. Может быть есть способ сделать это иначе?

    [SerializeReference] private Item_object item;
    public Stats stats = new Stats();
    public Active_item script_container;
    void Start()
    {
        InititalizeStats();
    }
    private void InititalizeStats()
    {
        stats._attackdmg = item._attackdmg;
        stats._attackspd = item._attackspd;
        stats._maxhp = item._maxhp;
        stats._movementspd = item._movementspd;
    }
}
