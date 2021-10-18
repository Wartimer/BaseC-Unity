using UnityEngine;

namespace RollABall.Player
{
    internal class BadBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            Debug.Log("BAD BONUS ACTIVATED");
        }
    }
}