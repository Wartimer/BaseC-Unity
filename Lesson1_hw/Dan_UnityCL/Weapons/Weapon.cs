using Dan_UnityCL.Inventory;
using UnityEngine;

namespace Dan_UnityCL.Weapons
{
    internal class Weapon : Item
    {
        internal int Damage { get; set; }
        
        public Weapon(int id, string name, GameObject pref, int damage) 
            : base(id, name, pref) 
        {
            Damage = damage;
        }
    }
}