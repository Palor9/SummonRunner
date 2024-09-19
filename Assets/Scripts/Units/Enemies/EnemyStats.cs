using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyStats : UnitStats
{
    internal Guid ID { get; set; }

    public EnemyStats()
    {
        Health = 50;
        Armor = 10;
        Speed = 20;
        DMG = 1;
        DamageSpeed = 10f;
        ID = Guid.NewGuid();
    }

    public void TakeDamage()
    {
        
    }
}
