using System;
using UnityEngine;

namespace RollABall.Player
{
    internal class Trap : InteractiveObject
    {
        protected override void Interaction()
        {
            Debug.Log("TRAP ACTIVATED");
        } 
        
    }
}