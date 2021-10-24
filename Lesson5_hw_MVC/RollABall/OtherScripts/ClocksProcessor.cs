using System;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.Player
{
    internal static class ClocksProcessor
    {
        private static List<IconFill> _clocks = new List<IconFill>();

        internal static void Subscribe(IconFill obj)
        {
            if(!_clocks.Contains(obj))
                _clocks.Add(obj);
        }
        
        public static void ProcessClocks()
        {
            if(BonusProcessor._bonusDurations.Count > 0)
                for(var i = BonusProcessor._bonusDurations.Count -1; i >= 0; i--)
                {
                    foreach (var c in _clocks)
                    {
                        if (c._id == BonusProcessor._bonusDurations[i].Id)
                        {
                            var fillAmt = Mathf.Clamp01((BonusProcessor._bonusDurations[i].RemainingTime /
                                          BonusProcessor._bonusDurations[i]._baseDuration));
                            c.DisplayDuration(fillAmt, BonusProcessor._bonusDurations[i].RemainingTime);
                            
                        }
                    }
                }
        }
        
        internal static void SortClocks()
        {
            _clocks.Sort();
        }

        internal static void ActivateClock(int id)
        {
            _clocks[id].gameObject.SetActive(true);
        }

        internal static void TurnOffClocks()
        {
            foreach (var c in _clocks)
            {
                c.gameObject.SetActive(false);
            }
        }

        internal static void ClearListOfClocks()
        {
            _clocks.Clear();
        }
        
        internal static void OnBonusDurationEnd(int id)
        {
            _clocks[id].gameObject.SetActive(false);
        }
    }
}