using System;
using UnityEngine;

namespace RollABall.Player
{
    internal abstract class Player : MonoBehaviour, IDisposable
    {
        private static event EventHandler<PlayerWinEventArgs> _playerWin;
        internal static event EventHandler<PlayerWinEventArgs> PlayerWin
        {
            add => _playerWin += value;
            remove => _playerWin -= value; 
        }
        
        internal int _points;
        public float _startSpeed = 3.0f;
        public float _speed;
        protected Rigidbody _rigidbody;

        internal bool Invulnerable { get; set; } = false;
        private void Awake()
        {
            _speed = _startSpeed;
            BonusProcessor.DurationEnd += OnBonusDurationEnd;
        }

        public abstract void Move(float x, float y, float z);

        internal void AddPoints(int points)
        {
            if (_points < 100)
            {
                _points += points;
            }

            if (_points >= 100)
            {
                _playerWin?.Invoke(this, new PlayerWinEventArgs(_points));
                Dispose();
            }
        }

        private void OnBonusDurationEnd(int id)
        {
            StatsReseter.ResetStats(this, id);
        }
        
        public void Dispose()
        {
            _rigidbody = null;
            BonusProcessor.DurationEnd -= OnBonusDurationEnd;
            PlayerMatController.ResetBaseMaterial();
            Destroy(gameObject);
        }
    }

}
