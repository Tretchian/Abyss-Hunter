using UnityEngine;
public class Item : MonoBehaviour
{
    //��� ���� ����� ������� �������� � �������� ������ �� scriptable object � stats. ����� ���� ���� ������ ������� ��� �����?

    [SerializeReference] private Item_object item;
    public Stats stats = new Stats();
    void Start()
    {
        InititalizeStats();
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = item.Sprite;
    }
    private void InititalizeStats()
    {
        stats._attackdmg = item._attackdmg;
        stats._attackspd = item._attackspd;
        stats._maxhp = item._maxhp;
        stats._movementspd = item._movementspd;
    }
}
