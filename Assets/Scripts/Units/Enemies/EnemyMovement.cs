using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using SummonRunner.Inputs.Units.HelpStructs;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : EnemyStats
{
    private Rigidbody2D _enemyPosition;

    private void Start()
    {
        _enemyPosition = GetComponent<Rigidbody2D>();
        EnemyDirector.RegisterEnemy(new EnemyBatch(_enemyPosition, this));
        this.Collider = _enemyPosition.GetComponent<Collider2D>();
    }
    
    public void Follow(Vector2 player)
    {
        this._enemyPosition.velocity =
            (player - this._enemyPosition.position).normalized * (this.Speed * Time.deltaTime);
    }

    public void OnDestroy()
    {
        EnemyDirector.RemoveByID(ID);
    }
}

