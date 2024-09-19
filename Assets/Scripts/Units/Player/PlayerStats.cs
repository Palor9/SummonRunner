using UnityEngine;

public class PlayerStats : UnitStats
{
    //private PlayerStats playerStats;
    public PlayerStats()
    {
        Health = 100f;
        Armor = 10;
        Speed = 1;
        DMG = 1;
    }
    private void Awake()
    {
        HealthBar.RegisterStats(this.Health);
    }
}
