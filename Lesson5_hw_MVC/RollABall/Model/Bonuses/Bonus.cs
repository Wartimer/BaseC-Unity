using UnityEngine;

namespace RollABall.Player
{
    internal abstract class Bonus : InteractiveObject, IExecute
    {
        protected override void Interaction()
        {
            Debug.Log("BONUS ACTIVATED");
        }

        public abstract void Execute();
    }
}