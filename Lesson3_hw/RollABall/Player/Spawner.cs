using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RollABall.Player
{
    [System.Serializable]
    internal sealed class Spawner
    {
        public List<GameObject> _trapsPrefs;
        internal List<GameObject> _spawnPoints;
        
        public Spawner()
        {
            _trapsPrefs = new List<GameObject>();
        }
    }
}