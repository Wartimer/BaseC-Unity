using System;
using UnityEngine;
using Object = System.Object;

namespace RollABall.Player
{
    internal sealed class ReturnTrap : Trap
    {
        private Vector3 _playerStartPos;

        protected override void Start()
        {
            base.Start();
            _playerStartPos = _player.transform.position;
        }
        
        protected override void Interaction()
        {
            base.Interaction();
            if(!_player.Invulnerable)
                _player.transform.position = _playerStartPos;
        }
    }
}