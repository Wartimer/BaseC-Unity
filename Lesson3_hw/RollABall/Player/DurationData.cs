using UnityEngine;

namespace RollABall.Player
{
    internal sealed class DurationData
    {
        internal float _baseDuration; 
        public DurationData(int id, float duration)
        {
            Id = id;
            _baseDuration = duration;
            RemainingTime = _baseDuration;
        }
        
        internal int Id { get; }
        internal float RemainingTime { get; set; }

        internal bool DecrementDuration(float deltaTime)
        {
            RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);
            return RemainingTime == 0f;
        }
    }
}