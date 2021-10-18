using System;

namespace RollABall.Player
{
    internal sealed class InterObjContainerEventArgs : EventArgs
    {
        private string _message;
        
        public InterObjContainerEventArgs(string message)
        {
            _message = message;
        }
    }
}