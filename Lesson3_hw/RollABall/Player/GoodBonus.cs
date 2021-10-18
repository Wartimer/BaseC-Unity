using UnityEngine;

namespace RollABall.Player
{
    internal class GoodBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            Debug.Log("GOOD BONUS ACTIVATED");
        }
    }
}