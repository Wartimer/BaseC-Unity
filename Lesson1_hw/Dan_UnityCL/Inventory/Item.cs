using UnityEngine;

namespace Dan_UnityCL.Inventory
{
    internal class Item : MonoBehaviour
    {
        internal int _id;
        internal string _name;
        internal GameObject _itemPref;
        
        public Item(int id, string name, GameObject pref)
        {
            this._id = id;
            this._name = name;
            this._itemPref = pref;
        }
    }
}