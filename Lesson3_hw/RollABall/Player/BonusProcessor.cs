using System;
using System.Collections.Generic;
using UnityEngine;


namespace RollABall.Player
{
    public static class BonusProcessor
    {
        public static event Action<int> DurationEnd;
        
        internal static List<DurationData> _bonusDurations = new List<DurationData>();

        public static void AddDuration(IHaveDuration obj)
        {
            if (InProcess(obj.Id))
                AddRemainingTime(obj.Id, obj.Duration);
            if(!InProcess(obj.Id))
                _bonusDurations.Add(new DurationData(obj.Id, obj.Duration));
        }
        
        
        public static void ProcessDurations()
        {
            var deltaTime = Time.deltaTime;
            for(int i = _bonusDurations.Count -1; i >= 0; i--)
            {
                if (_bonusDurations[i].DecrementDuration(deltaTime))
                {
                    DurationEnd?.Invoke(_bonusDurations[i].Id);
                    _bonusDurations.RemoveAt(i);
                }
            }
        }

        internal static bool InProcess(int id)
        {
            foreach (var d in _bonusDurations)
            {
                if (d.Id == id)
                {
                    return true;
                }   
            }
            
            return false;
        }

        static void AddRemainingTime(int id, float duration)
        {
            foreach (var d in _bonusDurations)
            {
                if (id == d.Id)
                {
                    d.RemainingTime += duration;
                    d._baseDuration += duration;
                }
            }
                        
        }
    }
}