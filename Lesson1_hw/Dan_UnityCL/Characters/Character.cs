using UnityEngine;

namespace Dan_UnityCL
{
    internal class Character : MonoBehaviour
    {
        internal int _id;
        internal string _name;
        internal GameObject _charPref;
        internal int _hp;
        internal bool _isDead;

        internal Character(int id, string name, GameObject charPref, int hp, bool isDead)
        {
            this._id = id;
            this._name = name;
            this._charPref = charPref;
            this._hp = hp;
            this._isDead = isDead;
        }
    }
}