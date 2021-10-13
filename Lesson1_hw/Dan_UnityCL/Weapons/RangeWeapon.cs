using UnityEngine;

namespace Dan_UnityCL.Weapons
{
    internal class RangeWeapon : Weapon
    {
        private int Damage { get; set; }
        private float _range;
        
        public RangeWeapon(int id, string name, GameObject pref, int damage, float range) 
            : base(id, name, pref, damage)
        {
            this._range = range;
        }
    }
}