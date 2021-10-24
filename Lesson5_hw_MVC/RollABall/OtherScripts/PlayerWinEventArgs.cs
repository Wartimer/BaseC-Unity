using System;

namespace RollABall.Player
{
    internal sealed class PlayerWinEventArgs : EventArgs
    {
        public int Points { get; }

        public PlayerWinEventArgs(int points)
        {
            Points = points;
        }
    }
}