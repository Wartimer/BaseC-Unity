using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall.Player
{
    internal sealed class TrapsSpawner : MonoBehaviour
    {
        public static event Action TrapsSpawned;
        
        private List<GameObject> _spawnPoints;
        [SerializeField]
        private List<GameObject> _trapPrefs;
        private GameObject _go;
        
        private void Start()
        {
            _spawnPoints = GameObject.FindGameObjectsWithTag("TrapSpawnPoint").ToList();
            SpawnTraps();
        }

        private void SpawnTraps()
        {
            foreach (var o in _spawnPoints)
            {
                _go = (GameObject) _trapPrefs[Random.Range(0, _trapPrefs.Count)].GetComponent<ICloneable>().Clone();
                _go.transform.position = o.transform.position;
                _go.transform.parent = o.transform;
            }
        
            TrapsSpawned?.Invoke();
        }
    }
}