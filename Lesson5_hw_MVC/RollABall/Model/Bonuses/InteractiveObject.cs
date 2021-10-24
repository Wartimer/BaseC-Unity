using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall.Player
{
    internal abstract class InteractiveObject : MonoBehaviour, IDisposable, ICloneable
    {
        internal static event Action BonusGathered;
        
        internal Player _player;

        private bool _isInteractable;

        protected bool IsInteractable
        {
            get => _isInteractable;
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }
        protected abstract void Interaction();

        protected virtual void Start()
        {
            IsInteractable = true;
            _player = FindObjectOfType<PlayerBall>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player")) return;
            BonusGathered?.Invoke();
            Interaction();
            IsInteractable = false;
            Dispose();
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }
        
        public void Dispose()
        {
            
            Destroy(gameObject);
        }
    }
}
