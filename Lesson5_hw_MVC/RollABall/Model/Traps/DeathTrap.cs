using System;

namespace RollABall.Player
{
    internal sealed class DeathTrap : Trap
    {
        internal delegate void CaughtPlayerChange(object value, Player player);
        internal event CaughtPlayerChange CaughtPlayer;
        
        protected override void Interaction()
        {
            base.Interaction();
            if (!_player.Invulnerable)
            {
                CaughtPlayer?.Invoke(this, _player);
            }
        }
    }
}