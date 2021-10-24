using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RollABall.Player
{
    [System.Serializable]
    internal sealed class Spawner
    {
        internal List<GameObject> _spawnPoints;
    }
}