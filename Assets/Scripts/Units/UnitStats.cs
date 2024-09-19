using UnityEngine;

public enum AttackType
{
    Range,
    Melee
}
public abstract class UnitStats : MonoBehaviour
{
    internal AttackType AttackType;
    internal float AttackRange; 
    internal float Health { get; set; }
    internal int Armor { get; set; }
    internal float Speed { get; set; }
    internal int DMG { get; set; }
    internal float CoordX { get; set; }
    internal float CoordY { get; set; }
    internal float DamageSpeed { get; set; }
    internal Collider2D Collider { get; set; }

    public void Movement (float coordx, float coordy)
    {
        CoordX = coordx * Speed;
        CoordY = coordy * Speed;
    }

}
