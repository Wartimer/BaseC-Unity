using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace RollABall.Player
{
    public class CameraController : IDisposable, IExecute 
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;
        private CameraShaker _cameraShaker;

        internal CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            //_mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        public void Execute()
        {
            if(_player)
                _mainCamera.position = _player.position + _offset;
        }
        
        
        public void Dispose()
        {
            _player = null;
        }
        
        // private void OnBonusGathered()
        // {
        //     if (_cameraShaker == null) throw new NullReferenceException();
        //     StartCoroutine(_cameraShaker.Shake(0.2f, 0.01f));
        // }
        
    }
}