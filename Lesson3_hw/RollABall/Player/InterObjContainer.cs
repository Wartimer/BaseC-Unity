using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace RollABall.Player
{
    [System.Serializable]
    internal sealed class InterObjContainer
    {
        private static event EventHandler<InterObjContainerEventArgs> _bonusesSubscribed;
        internal static event EventHandler<InterObjContainerEventArgs> BonusesSubscribed
        {
            add => _bonusesSubscribed += value;
            remove => _bonusesSubscribed -= value; 
        }
        
        [SerializeField]
        private List<GoodBonus> _goodBonuses;
        [SerializeField]
        private List<BadBonus> _badBonuses;

        internal int numberOfBonuses;
        public void Subscribe(IEnumerable<InteractiveObject> objects)
        {
            _goodBonuses ??= new List<GoodBonus>();
            _badBonuses ??= new List<BadBonus>();
            foreach (var o in objects)
            {
                switch (o)
                {
                    case GoodBonus bonus:
                        _goodBonuses.Add(bonus);
                        break;
                    case BadBonus bonus:
                        _badBonuses.Add(bonus);
                        break;
                }
            }
            _bonusesSubscribed?.Invoke(this, new InterObjContainerEventArgs("Bonuses Subscribed"));
        }

        public InteractiveObject this[int i]
        {
            get
            {
                var bonuses = _badBonuses.Cast<InteractiveObject>().ToList();
                bonuses.AddRange(_goodBonuses);
                numberOfBonuses = bonuses.Count - 1;
                return bonuses[i];
            }
        }
    }
}