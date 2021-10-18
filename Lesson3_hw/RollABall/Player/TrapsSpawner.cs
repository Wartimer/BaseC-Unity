using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall.Player
{
    internal sealed class TrapsSpawner : MonoBehaviour
    {
        internal static event Action TrapsSpawned;
        
        [SerializeField]
        internal Spawner spawner;
        
        private void Start()
        {
            spawner._spawnPoints = GameObject.FindGameObjectsWithTag("TrapSpawnPoint").ToList();
            
            foreach (var o in spawner._spawnPoints)
            {
                var go = (GameObject) spawner._trapsPrefs[Random.Range(0, spawner._trapsPrefs.Count)].GetComponent<ICloneable>().Clone();
                go.transform.position = o.transform.position;
                go.transform.parent = o.transform;
            }

            TrapsSpawned?.Invoke();
        }
    }
}