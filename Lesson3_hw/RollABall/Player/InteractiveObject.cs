using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall.Player
{
    internal abstract class InteractiveObject : MonoBehaviour, IInteractable, IDisposable, ICloneable
    {
        internal static event Action BonusGathered;
        
        internal Player _player;
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        protected virtual void Start()
        {
            _player = FindObjectOfType<PlayerBall>();
            //Привести объект к типу соответствующего интерфейса
            //((IAction)this).Action();
            //((IInitialization)this).Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player")) return;
            BonusGathered?.Invoke();
            Interaction();
            Dispose();
        }

        void IAction.Action()
        {
            if(TryGetComponent(out Renderer renderer))
                    renderer.material.color = Random.ColorHSV();
        }

        void IInitialization.Action()
        {
            if (TryGetComponent(out Renderer renderer))
                renderer.material.color = Color.cyan;
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
