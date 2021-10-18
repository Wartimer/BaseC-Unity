using UnityEngine;

namespace Dan_UnityCL.Inventory
{
    internal class AmmoPack : Item
    {
        private int _ammoToAdd;
        
        public AmmoPack(int id, string name, GameObject pref, int ammoToAdd) 
            : base(id, name, pref)
        {
            this._ammoToAdd = ammoToAdd;
        }
    }
}