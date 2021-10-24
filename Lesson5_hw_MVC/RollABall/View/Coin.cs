using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace RollABall.Player
{
    internal sealed class Coin : Bonus, IRotation
    {
        internal event Action<int> CoinGathered; 
        [SerializeField] private int _pointsAmount = 5;
        private float _speedRotation;
        
       
        private void Awake()
        {
            _speedRotation = Random.Range(10.0f, 50.0f);
        }
        
        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }
            Rotation();
        }
        
        protected override void Interaction()
        {
            base.Interaction();
            _player.AddPoints(_pointsAmount);
            CoinGathered?.Invoke(_pointsAmount);
        }
        
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}