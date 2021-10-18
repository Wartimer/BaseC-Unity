using System;
using UnityEngine;

namespace RollABall.Player
{
    internal class Player : MonoBehaviour, IDisposable
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
        private Rigidbody _rigidbody;
        internal DisplayPoints _displayPoints;

        internal bool Invulnerable { get; set; } = false;
        private void Awake()
        {
            _displayPoints = new DisplayPoints();
            _speed = _startSpeed;
            BonusProcessor.DurationEnd += OnBonusDurationEnd;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            PlayerMatController.SetMaterial(GetComponent<Renderer>().material);
        }

        protected void Move()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveForward = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0.0f, moveForward);
            _rigidbody.AddForce(movement * _speed);
        }

        internal void AddPoints(int points)
        {
            if (_points < 100)
            {
                _points += points;
                _displayPoints.Display(_points);
            }

            if (_points >= 100)
                _playerWin?.Invoke(this, new PlayerWinEventArgs(_points));
        }

        private void OnBonusDurationEnd(int id)
        {
            StatsReseter.ResetStats(this, id);
        }
        
        public void Dispose()
        {
            BonusProcessor.DurationEnd -= OnBonusDurationEnd;
            Destroy(gameObject);
        }
    }

}
