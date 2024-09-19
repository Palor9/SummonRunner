using UnityEngine;

namespace SummonRunner.Inputs.Units.HelpStructs
{
    public class EnemyBatch
    {
        public Rigidbody2D EnemyRigidbody2D;
        public EnemyMovement EnemyMovement;

        public EnemyBatch(Rigidbody2D enemyRigidbody2D, EnemyMovement enemyMovement)
        {
            this.EnemyRigidbody2D = enemyRigidbody2D;
            this.EnemyMovement = enemyMovement;
        }
    }
    
    public class PlayerBatch
    {
        public Rigidbody2D PlayerRigidbody2D;
        public PlayerMovement PlayerMovement;

        public PlayerBatch(Rigidbody2D playerRigidbody2D, PlayerMovement playerMovement)
        {
            this.PlayerRigidbody2D = playerRigidbody2D;
            this.PlayerMovement = playerMovement;
        }
    }
}