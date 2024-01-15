using UnityEngine;

[CreateAssetMenu(fileName = "Item", order = 1)]
public class Item_object : ScriptableObject
{
    public string Name;
    public string Description;
    public float _maxhp = 0f;
    public float _attackspd = 0f;
    public float _attackdmg = 0f;
    public float _movementspd = 0f;
}