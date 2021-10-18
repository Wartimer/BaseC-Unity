using UnityEngine;

namespace Dan_UnityCL.Inventory
{
    internal class HealthPotion : Item
    {
        private int _healthToAdd;
        
        public HealthPotion(int id, string name, GameObject pref, int healthToAdd) 
                            : base(id, name, pref)
        {
            this._healthToAdd = healthToAdd;
        }
    }
}