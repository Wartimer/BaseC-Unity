using Dan_UnityCL.Characters;
using UnityEngine;

namespace Dan_UnityCL
{
    internal class Enemy : Character, IAttack, IDamagable
    {
        
        public int Damage { get; set; }
        private int XpWorth { get; set; }

        internal Enemy(int id, string name, GameObject charPref, int hp, bool isDead, int damage, int xpWorth) 
            : base(id, name, charPref, hp, isDead)
        {
            this.Damage = damage;
            this.XpWorth = xpWorth;
        }

        public void Attack()
        {
           Debug.Log("Attacking Player");
           
        }

        public void TakeDamage(int damage)
        {
            if (this._hp > 0 && _isDead == false)
                _hp -= damage;
            if (this._hp <= 0)
            {
                _isDead = true;
                _hp = 0;
            }
        }
    }
}