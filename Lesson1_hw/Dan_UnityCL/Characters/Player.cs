using Dan_UnityCL.Characters;
using UnityEngine;

namespace Dan_UnityCL
{
    internal class Player : Character, IAttack, IDamagable
    {
       
        internal Player(int id, string name, GameObject charPref, int hp, bool isDead, int damage) 
            : base(id, name, charPref, hp, isDead)
        {
            
        }

        public void Attack()
        {
            Debug.Log("Attack Enemy");
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