using UnityEngine;

namespace Dan_UnityCL.Weapons
{
    internal class MeleeWeapon : Weapon
    {
        private int Damage { get; set; }
        private float _attackRate;
        
        public MeleeWeapon(int id, string name, GameObject pref, int damage, float attackRate) 
                                : base(id, name, pref, damage)
        {
            this._attackRate = attackRate;
        }
    }
}