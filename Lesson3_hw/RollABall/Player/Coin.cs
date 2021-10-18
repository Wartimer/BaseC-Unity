using UnityEngine;

namespace RollABall.Player
{
    internal sealed class Coin : GoodBonus, IRotation
    {
        [SerializeField] private int _pointsToAdd = 5;
        private float _speedRotation;
        
       
        private void Awake()
        {
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            base.Interaction();
            _player.AddPoints(_pointsToAdd);
        }
        
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}