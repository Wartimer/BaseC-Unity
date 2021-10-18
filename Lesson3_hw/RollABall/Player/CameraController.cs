using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace RollABall.Player
{
    public class CameraController : MonoBehaviour, IDisposable
    {
        private Player _player;
        private Vector3 _offset;
        private CameraShaker _cameraShaker;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _cameraShaker = GetComponentInChildren<CameraShaker>();
            InteractiveObject.BonusGathered += OnBonusGathered;
            
            _offset = transform.position - _player.transform.position;
        }


        private void LateUpdate()
        {
            if(_player != null)
                transform.position = _player.transform.position + _offset;
        }

        public void Dispose()
        {
            InteractiveObject.BonusGathered -= OnBonusGathered;
        }
        
        private void OnBonusGathered()
        {
            if (_cameraShaker == null) throw new NullReferenceException();
            StartCoroutine(_cameraShaker.Shake(0.2f, 0.01f));
        }
        
    }
}