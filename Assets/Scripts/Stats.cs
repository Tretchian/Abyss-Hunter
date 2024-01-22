

public class Stats
{
    public float _maxhp = 0f;
    public float _attackspd = 0f;
    public float _attackdmg = 0f;
    public float _movementspd = 0f;
    public Stats() {
    }
    public Stats( float maxhp, float attackspd, float attackdmg, float movementspd)
    {
        _maxhp = maxhp;
        _attackspd = attackspd;
        _attackdmg = attackdmg;
        _movementspd = movementspd;
    }
    public void addStats(Stats stats)
    {
        this._maxhp += stats._maxhp;
        this._attackspd += stats._attackspd;
        this._attackdmg += stats._attackdmg;
        this._movementspd += stats._movementspd;
    }
    public void removeStats(Stats stats)
    {
        this._maxhp -= stats._maxhp;
        this._attackspd -= stats._attackspd;
        this._attackdmg -= stats._attackdmg;
        this._movementspd -= stats._movementspd;
    }
}
