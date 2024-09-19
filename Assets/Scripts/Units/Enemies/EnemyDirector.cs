using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;
using System;
using SummonRunner.Inputs.Units.HelpStructs;

public class EnemyDirector : MonoBehaviour
{
    public static Dictionary<Guid, EnemyBatch> EnemyMovements = new Dictionary<Guid, EnemyBatch>();

    internal static PlayerBatch PlayerBatch;

    private float _destroyTime;

    public static void RegisterEnemy(EnemyBatch enemy)
    {
        EnemyMovements.Add(enemy.EnemyMovement.ID, enemy);
    }

    public void FixedUpdate()
    {
        foreach (var movement in EnemyMovements)
        {
            movement.Value.EnemyMovement.Follow(PlayerBatch.PlayerRigidbody2D.position);
        }
    }


    public static void RegisterPlayer(PlayerBatch playerBatch)
    {
        PlayerBatch = playerBatch;
    }

    public static void RemoveByID(Guid iD)
    {
        EnemyMovements.Remove(iD);
    }
}
