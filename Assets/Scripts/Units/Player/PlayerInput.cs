using SummonRunner.Inputs;
using SummonRunner.Inputs.Units.HelpStructs;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 _movement;
        private PlayerMovement _playerMovement;


        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            EnemyDirector.RegisterPlayer(new PlayerBatch
                (_playerMovement.GetComponent<Rigidbody2D>(), _playerMovement));
            
            ProjectileDirector.RegisterPlayer(_playerMovement);
            _playerMovement.Collider = _playerMovement.GetComponent<Collider2D>();
        }

        private void Update()
        {
            float horisontal = Input.GetAxis(GlobalStringVars.HORIZANTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            //float mouseLeftClick = Input.GetAxis(GlobalStringVars.MOUSE_X);

            _movement = new Vector2(horisontal, vertical);
        }

        private void FixedUpdate()
        {
            _playerMovement.MoveCaracter(_movement);
        }
    }
}